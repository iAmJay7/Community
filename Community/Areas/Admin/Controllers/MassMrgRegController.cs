using Community.Areas.Admin.Models;
using Community.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Community.Areas.Admin.Controllers
{
    public class MassMrgRegController : Controller
    {
        // GET: Admin/MassMrgReg
        public ActionResult Index(int id)
        {
            SessionWrapper.MassMrgId = id;
            return View(MassMrgRegRepository.GetMrgByMassId(SessionWrapper.MassMrgId));
        }

        [HttpPost]
        public ActionResult Create(MassMrgRegViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (MassMrgRegRepository.Add(model))
                {
                    return Json(MassMrgRegRepository.GetMrgByMassId(SessionWrapper.MassMrgId));
                }
            }
            return Content("Can't");
        }

        public ActionResult FetchMrgByMassId(int id)
        {
            return Json(MassMrgRegRepository.GetMrgByMassId(id));
        }
        [HttpPost]
        public ActionResult OrderBy(string orderBy)
        {
            return Json(MassMrgRegRepository.GetsOrderBy(int.Parse(orderBy)));

        }
    }
}