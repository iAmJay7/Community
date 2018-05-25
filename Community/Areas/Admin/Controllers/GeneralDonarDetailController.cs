using Community.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Community.Areas.Admin.Controllers
{
    public class GeneralDonarDetailController : Controller
    {
        // GET: Admin/GeneralDonarDetail
        public ActionResult Index()
        {
            return View(GeneralDonarDetailRepository.Gets());
        }

        [HttpPost]
        public ActionResult Create(GeneralDonarDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (GeneralDonarDetailRepository.Add(model))
                {
                    return Json(GeneralDonarDetailRepository.Gets());
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult OrderBy(string orderBy)
        {
            return Json(GeneralDonarDetailRepository.GetsOrderBy(int.Parse(orderBy)));

        }
    }
}