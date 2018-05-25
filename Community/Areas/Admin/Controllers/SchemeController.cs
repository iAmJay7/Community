using Community.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Community.Areas.Admin.Controllers
{
    public class SchemeController : Controller
    {
        // GET: Admin/Scheme
        public ActionResult Index()
        {
            return View(SchemeRepository.Gets());
        }

        [HttpPost]
        public ActionResult Create(SchemeViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (SchemeRepository.Add(model))
                {
                    return Json(SchemeRepository.Gets());
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult OrderBy(string orderBy)
        {
            return Json(SchemeRepository.GetsOrderBy(int.Parse(orderBy)));

        }
    }
}