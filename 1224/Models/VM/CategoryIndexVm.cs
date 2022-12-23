using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Runtime.InteropServices;

namespace _1224.Models.VM
{
    public class CategoryIndexVm
    {
        public int Id { get; set; }

        [Display(Name = "分類名稱")]
        public string CategoryName { get; set; }

        [Display(Name = "商品數量")]
        public int ProductCount { get; set; }

        [Display(Name = "顯示順序")]
        public int DisplayOrder { get; set; }
    }
}