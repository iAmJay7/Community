using Community.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Community.Areas.Admin.Controllers
{
    public class VillageController : Controller
    {
        // GET: Admin/Village
        public ActionResult Index()
        {
            return View(VillageRepository.Gets());
        }


        [HttpPost]
        public ActionResult Create(VillageViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (VillageRepository.Add(model))
                {
                    return Content("Created");
                }
                else
                {
                    return Content("Cant Created");
                }
            }
            return View();
        }
    }
}