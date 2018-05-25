using Community.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Community.Areas.Admin.Controllers
{
    public class GeneralLoanController : Controller
    {
        // GET: Admin/GeneralLoan
        public ActionResult Index()
        {
            return View(GeneralLoanRepository.Gets());
        }

        [HttpPost]
        public ActionResult Create(GeneralLoanViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (GeneralLoanRepository.Add(model))
                {
                    return Json(GeneralLoanRepository.Gets());
                }
            }
            return View();
        }

        

        [HttpPost]
        public ActionResult OrderBy(string orderBy)
        {
            return Json(GeneralLoanRepository.GetsOrderBy(int.Parse(orderBy)));
            
        }
    }
}