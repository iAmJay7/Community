using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Community.Areas.Admin.Controllers
{
    public class DashBoardController : Controller
    {
        // GET: Admin/DashBoard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MassMrg(int id)
        {
            ViewBag.id = id;
            return View(ViewBag);
        }
    }
}