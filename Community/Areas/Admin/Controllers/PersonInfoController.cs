using Community.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Community.Areas.Admin.Controllers
{
    public class PersonInfoController : Controller
    {
        // GET: Admin/PersonInfo
        public ActionResult Index()
        {
            return View(PersonInfoDao.Gets());
        }

        [HttpPost]
        public ActionResult Create(PersonInfoVModel model,HttpPostedFileBase file)
        {
            
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    string filename = Path.GetFileName(file.FileName);
                    model.Photo=filename;
                    string path = Path.Combine(Server.MapPath("~/Content/Images"), filename);
                    file.SaveAs(path);
                }
                if (PersonInfoDao.Add(model))
                {
                    return View(PersonInfoDao.Gets());
                }
            }
            return Content("Can't");
        }

        [HttpPost]
        public ActionResult OrderBy(string orderBy)
        {
            return Json(PersonInfoDao.GetsOrderBy(int.Parse(orderBy)));
        }
    }
}