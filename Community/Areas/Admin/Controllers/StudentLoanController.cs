using Community.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Community.Areas.Admin.Controllers
{
    public class StudentLoanController : Controller
    {
        // GET: Admin/StudentLoan
        public ActionResult Index()
        {
            return View(StudentLoanRepository.Gets());
        }

        [HttpPost]
        public ActionResult Create(StudentLoanViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (StudentLoanRepository.Add(model))
                {
                    return Json(StudentLoanRepository.Gets());
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult OrderBy(string orderBy)
        {
            return Json(StudentLoanRepository.GetsOrderBy(int.Parse(orderBy)));

        }
    }
}