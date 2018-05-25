using Community.Areas.Admin.Models;
using Community.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Community.Areas.Admin.Controllers
{
    public class MassMrgExpenditureController : Controller
    {
        // GET: Admin/MassMrgExpenditure
        public ActionResult Index()
        {
            return View(MassMrgExpenditureRepository.GetsByMassMrgId(SessionWrapper.MassMrgId));
        }

        [HttpPost]
        public ActionResult Create(MassMrgExpenditureViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (MassMrgExpenditureRepository.Add(model))
                {
                    return Json(MassMrgExpenditureRepository.GetsByMassMrgId(SessionWrapper.MassMrgId));
                }
            }
            return Content("Can't");
        }
        [HttpPost]
        public ActionResult OrderBy(string orderBy)
        {
            return Json(MassMrgExpenditureRepository.GetsOrderBy(int.Parse(orderBy)));

        }
    }
}