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
        public ActionResult IncrementViewCount(int? id)
        {
            var result = (from v in db.Videos
                             where v.videoID == id
                             select v).SingleOrDefault();

            result.viewsCount++; 
            db.SaveChanges();



            return Redirect("~/NavigationBar/Index");
            //return RedirectToAction("VideoPlayer","Misc", new { id });
        }

        public ActionResult MyProfile()
        {
            int id = (int)Session["userID"];

            var result = (from c in db.CertUsers
                         where c.certUserID == id
                         select c).SingleOrDefault();
                         //{
                         //    c.username,
                         //    c.firstName,
                         //    c.lastName,
                         //    c.balance,
                         //    c.email,
                         //};




            return View(result);
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

        //public ActionResult Registration()
        //{
        //    ViewBag.Message = "Registration";
        //    return View();
        //}
    }
}