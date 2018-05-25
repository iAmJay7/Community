using Community.Areas.Admin.Models;
using Community.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Community.Areas.Admin.Controllers
{
    public class MassMrgDonarDetailController : Controller
    {
        // GET: Admin/MassMrgDonarDetail
        public ActionResult Index()
        {
            return View(MassMrgDonarDetailRepository.GetsByMassMrgId(SessionWrapper.MassMrgId));
        }

        [HttpPost]
        public ActionResult Create(MassMrgDonarDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (MassMrgDonarDetailRepository.Add(model))
                {
                    return Json(MassMrgDonarDetailRepository.GetsByMassMrgId(SessionWrapper.MassMrgId));
                }
            }
            return Content("Can't");
        }
        [HttpPost]
        public ActionResult OrderBy(string orderBy)
        {
            return Json(MassMrgDonarDetailRepository.GetsOrderBy(int.Parse(orderBy)));

        }
    }
}