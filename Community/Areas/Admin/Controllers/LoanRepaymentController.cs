using Community.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Community.Areas.Admin.Controllers
{
    public class LoanRepaymentController : Controller
    {
        // GET: Admin/LoanRepayment
        public ActionResult Index()
        {
            return View(LoanRepaymentRepository.Gets());
        }

        [HttpPost]
        public ActionResult Create(LoanRepaymentViewModel model)
        {
                if (LoanRepaymentRepository.Add(model))
                {
                    return Json(LoanRepaymentRepository.Gets());
                }
                return Json("fail");
            
        }
        [HttpPost]
        public ActionResult OrderBy(string orderBy)
        {
            return Json(LoanRepaymentRepository.GetsOrderBy(int.Parse(orderBy)));

        }

    }

    
}