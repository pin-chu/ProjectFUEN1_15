﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using ProjectFUEN.Models.VM;
using System;
using System.Collections.Generic;

namespace ProjectFUEN.Models.EFModels
{
    public partial class ProductPhoto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Source { get; set; }

        public virtual Product Product { get; set; }
    }
    public static partial class PhotoExts
    {
        public static ProductPhoto ToEntity(this ProductPhotoVM source)
        {
            return new ProductPhoto
            {
                Id = source.Id,
                ProductId = source.ProductId,
                Source = source.Source,
            };
        }
    }
}