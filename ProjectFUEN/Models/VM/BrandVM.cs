﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjectFUEN.Models.VM
{
    public class BrandVM
    {
        public int Id { get; set; }
        [Display(Name = "品牌名稱")]
		public string Name { get; set; }

    }
}
