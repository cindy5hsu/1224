using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1224.Models.EFModels
{
    public class ProductIndexVm
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

       
        public string ProductName { get; set; }

        public int UnitPrice { get; set; }
    }
}