using Community.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Community.Areas.Admin.Controllers
{
    public class LoanTypeController : Controller
    {
        // GET: Admin/LoanType
        public ActionResult Index()
        {
            return View(LoanTypeRepository.Gets());
        }

        [HttpPost]
        public ActionResult Create(LoanTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (LoanTypeRepository.Add(model))
                {
                    return Json(LoanTypeRepository.Gets());
                }
            }
            return View();
        }
    }
}