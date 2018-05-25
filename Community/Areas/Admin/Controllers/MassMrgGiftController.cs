using Community.Areas.Admin.Models;
using Community.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Community.Areas.Admin.Controllers
{
    public class MassMrgGiftController : Controller
    {
        // GET: Admin/MassMrgGift
        public ActionResult Index()
        {
            return View(MassMrgGiftRepository.GetsByMassMrgId(SessionWrapper.MassMrgId));
        }

        [HttpPost]
        public ActionResult Create(MassMrgGiftViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (MassMrgGiftRepository.Add(model))
                {
                    return Json(MassMrgGiftRepository.GetsByMassMrgId(SessionWrapper.MassMrgId));
                }
            }
            return Content("Can't");
        }
        [HttpPost]
        public ActionResult OrderBy(string orderBy)
        {
            return Json(MassMrgGiftRepository.GetsOrderBy(int.Parse(orderBy)));

        }
    }
}