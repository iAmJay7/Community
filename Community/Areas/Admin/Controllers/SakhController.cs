using Community.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Community.Areas.Admin.Controllers
{
    public class SakhController : Controller
    {
        // GET: Admin/Sakh
        public ActionResult Index()
        {
            return View(SakhRepository.Gets());
        }

        [HttpPost]
        public ActionResult Create(SakhViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (SakhRepository.Add(model))
                {
                    return Content("Create");
                }
                else
                {
                    return Content("Cant create");
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult SakhsByVillageId(int villageId)
        {
            return Json(SakhRepository.GetsSakhsBtVillage(villageId));
        }
    }
}