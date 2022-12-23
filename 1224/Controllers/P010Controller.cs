using _1224.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1224.Controllers
{
    public class P010Controller : Controller
    {
        // GET: P010
        public ActionResult A01()
        {
            return View();
        }

        [HttpPost]
        public ActionResult A01(P010A01VM model) 
        {
            //return RedirectToAction("Index", "Home");
            #region save file
            if (model.File == null || string.IsNullOrEmpty(model.File.FileName) || model.File.ContentLength == 0)
            {
                model.FileName=string.Empty;
            }
            else
            {
                string path = Server.MapPath("/Uploads");
                string fileName = System.IO.Path.GetFileName(model.File.FileName);

                string newFileName = GetNewFileName(path, fileName);
      
                string fullPath = System.IO.Path.Combine(path, fileName);
                try
                {
                    model.File.SaveAs(fullPath);
                    model.FileName = fileName;

                    return View();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "上傳檔案失敗" + ex.Message);
                }
            }
            #endregion 
            return RedirectToAction("Index", "Home");
        }

        private string GetNewFileName(string path, string fileName)
        {
                string ext = System.IO.Path.GetExtension(fileName);//取得副檔名 eg:.jpg
                string newFileName = string.Empty;
                string fullPath = string.Empty;
                do
                {
                 newFileName = Guid.NewGuid().ToString("N") + ext;
                fullPath = System.IO.Path.Combine(path, newFileName);
                } while (System.IO.File.Exists(fullPath)==true);

                return newFileName;
           
        }
    }
}