using Community.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Community.Areas.Member.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Member/Dashboard
        public ActionResult Index()
        {
            return View(PersonInfoRepository.GetPersonById(SessionWrapper.UserId));
        }

        public ActionResult Test()
        {
            return View();
        }
        
        
    }
}