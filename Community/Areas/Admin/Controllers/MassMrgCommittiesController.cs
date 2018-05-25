using Community.Areas.Admin.Models;
using Community.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Community.Areas.Admin.Controllers
{
    public class MassMrgCommittiesController : Controller
    {
        // GET: Admin/MassMrgCommitties
        [HttpGet]
        public ActionResult Index()
        {
            return View(MassMrgCommittiesRepository.GetsByMassMrgId(SessionWrapper.MassMrgId));
        }

        [HttpPost]
        public ActionResult Create(MassMrgCommittiesViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (MassMrgCommittiesRepository.Add(model))
                {
                    return Json(MassMrgCommittiesRepository.GetsByMassMrgId(SessionWrapper.MassMrgId));
                }
            }
            return View("Can't");
        }
        [HttpPost]
        public ActionResult OrderBy(string orderBy)
        {
            return Json(MassMrgCommittiesRepository.GetsOrderBy(int.Parse(orderBy)));

        }
    }
}