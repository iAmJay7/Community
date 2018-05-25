using Community.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Community.Controllers
{
    public class HomeController : Controller
    {
        public object ApplicationController { get; private set; }

        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (LoginDetailRepository.Login(model))
                {
                    model.Id = PersonInfoRepository.GetIdByEmail(model.Email);
                    SessionWrapper.UserId = model.Id;
                    SessionWrapper.UserName = PersonInfoRepository.GetNameById(model.Id);
                    return RedirectToAction("index","dashboard",new { area="Member"});
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(PersonInfoViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (PersonInfoRepository.Add(model))
                {
                    return Content("Created");
                }
                else
                {
                    return Content("Cant");
                }
            }
            return View();
        }

        
        public ActionResult FetchPerson(int sakhId)
        {
            return Json(PersonInfoRepository.FetchPersonsListBySakhId(sakhId));
        }

        public ActionResult FetchPersonByVillageId(int id)
        {
            return Json(PersonInfoRepository.GetsByVillageId(id));
        }

        public ActionResult GetPersonNameById(int id)
        {
            return Content(PersonInfoRepository.GetNameById(id));
        }
    }
}