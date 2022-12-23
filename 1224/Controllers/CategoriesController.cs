using _1224.Models.EFModels;
using _1224.Models.VM;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1224.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Catefories
        public ActionResult Index()
        {
            var db = new AppDbContext();

          
            // 用此寫法, 在query 時就指定要傳回哪些欄位,生成的 sql statement會比較精簡, 有效率
            var data = db.Categories
             .Select(c => new
             {
                 Id = c.Id,
                 CategoryName = c.CategoryName,
                 ProductCount = c.Products.Count,
                 DisplayOrder = c.DisplayOrder
             })
              .ToList() 
             .Select(x => new CategoryIndexVm
             {
                 Id = x.Id,
                 CategoryName = x.CategoryName,
                 DisplayOrder = x.DisplayOrder,
                 ProductCount = x.ProductCount
             });

            return View(data);
        }
        public ActionResult index02()
        {
            var db = new AppDbContext();

            var data = db.Categories.Include("Products").ToArray();

            return View(data);
        }
            //return View(data);
    }
}