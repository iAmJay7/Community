using Community.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Community.Areas.Admin.Controllers
{
    public class MassMrgController : Controller
    {
        // GET: Admin/MassMrg
        public ActionResult Index()
        {
            return View(MassMrgRepository.Gets());
        }

        [HttpPost]
        public ActionResult Create(MassMrgViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (MassMrgRepository.Add(model))
                {
                    return Json(MassMrgRepository.Gets());
                }
            }
            return Content("Can't");
        }
        [HttpPost]
        public ActionResult OrderBy(string orderBy)
        {
            return Json(MassMrgRepository.GetsOrderBy(int.Parse(orderBy)));

        }
    }
}