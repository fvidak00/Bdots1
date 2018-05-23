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
            int sid = (int)Session["userID"];
            var result = (from v in db.Videos
                             where v.videoID == id
                             select v).SingleOrDefault();
            if(result.CertUser.balance < result.price && result.userID!=sid)
            {

                //tu dodje neka poruka
                return View();
            }
            else
            {
                result.viewsCount++;
                if(result.userID != sid)
                {
                    var payer = (from p in db.CertUsers
                                where p.certUserID == sid
                                select p).SingleOrDefault();
                    payer.balance -= result.price;
                }
                db.SaveChanges();

                return RedirectToAction("VideoPlayer", new { id });
            }
            
        }


        public ActionResult VideoPlayer(int? id)
        {
            var result = (from v in db.Videos
                               where v.videoID == id
                               select v).FirstOrDefault();
            return View(result);
        }

        public ActionResult MyProfile()
        {
            int id = (int)Session["userID"];

            var result = (from c in db.CertUsers
                         where c.certUserID == id
                         select c).SingleOrDefault();

            return View(result);
        }

        public ActionResult MyVideos()
        {
            int sid = (int)Session["userID"];
            var videos = from v in db.Videos
                         where v.userID==sid
                         select v;


            return View(videos);
        }

        public ActionResult Upload()
        {
            ViewBag.Message = "Upload page";
            return View();
        }

        public ActionResult Transactions()
        {
            if (Session["userID"] != null)
            {
                ViewBag.Message = "Transactions";
                int sid = (int)Session["userID"];
                var transactions = from t in db.Payments
                                   where (t.Payers.certUserID == sid || t.Receivers.certUserID == sid)
                                   select t;
                return View(transactions);
            }
            else
                return View();
        }

        public ActionResult Edit()
        {
            int id=(int)Session["userID"];
            var result = db.CertUsers.Single(m => m.certUserID == id);
            return View(result);

        }
        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            try
            {
                int id= (int)Session["userID"]; 
                var result = db.CertUsers.Single(m => m.certUserID == id);
                if (TryUpdateModel(result))
                {
                    db.SaveChanges();
                    return RedirectToAction("MyProfile");
                }
                return View(result);
            }
            catch
            {
                return View();
            }

        }

        public ActionResult EditVideo(int? id)
        {

            return View();
        }
        public ActionResult DeleteVideo(int? id)
        {
            var dVideo = (from v in db.Videos
                         where v.videoID == id
                         select v).SingleOrDefault();

            db.Videos.Remove(dVideo);
            db.SaveChanges();

            return RedirectToAction("MyVideos");
        }
    }
}