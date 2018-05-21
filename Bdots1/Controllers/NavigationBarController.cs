using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bdots1.Controllers
{
    public class NavigationBarController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyProfile()
        {
            ViewBag.Message = "Your profile";


            return View();
        }

        public ActionResult MyVideos()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Upload()
        {
            ViewBag.Message = "Upload page";
            return View();
        }

        public ActionResult Transactions()
        {
            ViewBag.Message = "Transactions";
            return View();
        }

        //public ActionResult Registration()
        //{
        //    ViewBag.Message = "Registration";
        //    return View();
        //}
    }
}