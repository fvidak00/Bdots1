using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bdots1.Controllers
{
    public class NavigationBarController : Controller
    {
        private BDEntities db = new BDEntities();

        public ActionResult Index()
        {

            var videos = from v in db.Videos
                         select v;



                        
            return View(videos);
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

            var transactions = from t in db.Payments
                               select t;

            return View(transactions);
        }
    }
}