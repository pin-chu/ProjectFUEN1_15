﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fileUpload.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectFUEN.Models.EFModels;
using ProjectFUEN.Models.Infrastructures.Repositories;
using ProjectFUEN.Models.Services.interfaces;
using ProjectFUEN.Models.Services;
using ProjectFUEN.Models.VM;

namespace ProjectFUEN.Controllers
{
    public class ProductPhotoesController : Controller
    {
        FileManager fileManager;
        private readonly ProjectFUENContext _context;
        private IProductPhotoService productPhotoService;

        public ProductPhotoesController(ProjectFUENContext context)
        {
            fileManager = new FileManager();
            _context = context;
            IProductPhotoRepository repo = new ProductPhotoRepository(_context);
            this.productPhotoService = new IProductPhotoService(repo);
        }


        // GET: ProductPhotoes1
        public IActionResult Index(int id)
        //public ActionResult Index()
        {
            List<ProductPhotoVM> data = (from p in _context.ProductPhotos.Where(x => x.ProductId == id)
                                         join x in _context.Products on p.ProductId equals x.Id
                                         select new ProductPhotoVM
                                         {
                                             Id = p.Id,
                                             ProductId = p.ProductId,
                                             Source = p.Source,
                                         }).ToList();
            //var projectFUENContext = _context.ProductPhotos.Where(x=>x.ProductId == id)
            //       .Select(c => new ProductPhotoVM
            //       {
            //           Id = c.Id,
            //           ProductId = c.ProductId,
            //           Source = c.Source,
            //       }).ToList();
            return View(data);
        
        }

        // GET: ProductPhotoes1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductPhotos == null)
            {
                return NotFound();
            }

            var productPhoto = await _context.ProductPhotos
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productPhoto == null)
            {
                return NotFound();
            }

            return View(productPhoto);
        }

        // GET: ProductPhotoes1/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");
            return View();
        }

        // POST: ProductPhotoes1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductPhotoVM vm)
        {
            // 圖片Copy to project的資料夾
            foreach (var file in vm.Sources)
            {
                //上傳照片
                (bool isCopied, string message, string Source) uploadSuccess = fileManager.UploadFile(file);

                // 失敗呈現在View上面
                if (!uploadSuccess.isCopied)
                {
                    ViewBag.photo = uploadSuccess.message;
                    return View(vm);
                }
            }
            ////存取資料庫
            //ProductPhoto productPhoto = new ProductPhoto()
            //{
            //    Id = vm.Id,
            //    ProductId = vm.ProductId,
            //    Source = vm.Source
            //};
            _context.ProductPhotos.AddRange(vm.Sources.Select(x => new ProductPhoto()
            {
                ProductId = vm.ProductId,
                Source = x.FileName
            }));
            try
            {
                _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
            }
            //return RedirectToAction(nameof(Index));
            //if (ModelState.IsValid)
            //{
            //    _context.Add(vm.ToEntity());
            //    _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", vm.ProductId);
            return RedirectToAction(nameof(Index),"Products");
        }

        // GET: ProductPhotoes1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductPhotos == null)
            {
                return NotFound();
            }

            var productPhoto = await _context.ProductPhotos.FindAsync(id);
            if (productPhoto == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", productPhoto.ProductId);
            return View(productPhoto);
        }

        // POST: ProductPhotoes1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IFormFile file, int id, [Bind("Id,ProductId,Source")] ProductPhotoVM productPhoto)
        {
            if (id != productPhoto.Id)
            {
                return NotFound();
            }
            //判斷是否有上傳圖檔，若檔案類型/未上傳 回傳錯誤訊息，上傳成功回傳新檔名，錯誤訊息=""
            (bool, string, string) uploadSuccess = fileManager.UploadFile(file);

            //上傳檔案失敗(沒上傳東西/上傳圖檔以外的)=>
            //有上傳檔案=>判斷有沒有跳檔案錯誤的訊息，沒跳就將新的檔案(uploadSuccess.Item3)更新到instructor.ResumePhoto


            if (!uploadSuccess.Item1)//上傳失敗 item1=false
            {

                if (uploadSuccess.Item2 == "記得選取檔案") //未上傳任何檔案，用原有的
                {
                    ModelState.Remove("file");
                    if (ModelState.IsValid)
                    {
                        _context.Update(productPhoto.ToEntity());
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));

                    }
                }
                else if (uploadSuccess.Item2 == "檔案必須是圖片檔案")//上傳成圖檔以外的
                {
                    ViewBag.photoError = uploadSuccess.Item2; //錯誤訊息
                    return View(productPhoto);
                }
                return View(productPhoto);
            }
            else //有上傳檔案
            {
                if (uploadSuccess.Item2 == "") //上傳圖檔，錯誤訊息=""
                {
                    productPhoto.Source = uploadSuccess.Item3; //傳入新檔名
                    _context.Update(productPhoto.ToEntity());
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else //上傳圖檔以外的(ppt.pdf...)
                {
                    ViewBag.photoError = uploadSuccess.Item2;
                    return View(productPhoto);
                }
                //ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", productPhoto.ProductId);
                //return View(productPhoto);

            }


            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(productPhoto);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!ProductPhotoExists(productPhoto.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
           
        }

        // GET: ProductPhotoes1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductPhotos == null)
            {
                return NotFound();
            }

            var productPhoto = await _context.ProductPhotos
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productPhoto == null)
            {
                return NotFound();
            }

            return View(productPhoto);
        }

        // POST: ProductPhotoes1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductPhotos == null)
            {
                return Problem("Entity set 'ProjectFUENContext.ProductPhotos'  is null.");
            }
            var productPhoto = await _context.ProductPhotos.FindAsync(id);
            if (productPhoto != null)
            {
                _context.ProductPhotos.Remove(productPhoto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductPhotoExists(int id)
        {
          return _context.ProductPhotos.Any(e => e.Id == id);
        }
        public async Task<IActionResult> DeleteoOneSelf(int id)
        {
            var photo = await _context.ProductPhotos.FindAsync(id);
            _context.ProductPhotos.Remove(photo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", photo.ProductId);
        }
    }
}
