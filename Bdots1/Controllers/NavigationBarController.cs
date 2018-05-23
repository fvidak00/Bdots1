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

        public ActionResult Index(int insufficientFunds = 0)
        {
            if (insufficientFunds == 0)
                ViewBag.Message = "";
            else
                ViewBag.Message = "Not enough gold, milord.";
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

            var payer = (from p in db.CertUsers
                         where p.certUserID == sid
                         select p).SingleOrDefault();

            var receiver = (from r in db.CertUsers
                            where r.certUserID == result.userID
                            select r).SingleOrDefault();


            if (payer.balance < result.price && result.userID != sid)
            {
                return RedirectToAction("Index", new { insufficientFunds = 1 });
            }
            else
            {
                result.viewsCount++;
                if (result.userID != sid)
                {
                    receiver.balance += result.price;
                    payer.balance -= result.price;
                }
                db.SaveChanges();

                return RedirectToAction("VideoPlayer", new { id });
            }

        }


        public ActionResult VideoPlayer(int? id)
        {
            if (id != null)
            {
                var result = (from v in db.Videos
                              where v.videoID == id
                              select v).FirstOrDefault();
                return View(result);
            }
            else
                return Redirect("~/Login/Index");

        }

        public ActionResult MyProfile(int profileUpdated = 0)
        {
            try
            {
                int id = (int)Session["userID"];
                switch (profileUpdated)
                {

                    case 1:
                        ViewBag.Message = "Profile updated successfully.";
                        break;
                    case 2:
                        ViewBag.Message = "Profile update failed.";
                        break;
                    case 0:
                    default:
                        ViewBag.Message = "";
                        break;
                }

                var result = (from c in db.CertUsers
                              where c.certUserID == id
                              select c).SingleOrDefault();
                return View(result);
            }
            catch
            {
                return Redirect("~/Login/Index");
            }

        }

        public ActionResult MyVideos()
        {
            try
            {
                int sid = (int)Session["userID"];
                var videos = from v in db.Videos
                             where v.userID == sid
                             select v;


                return View(videos);
            }
            catch
            {
                return Redirect("~/Login/Index");
            }
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
                return Redirect("~/Login/Index");
        }

        public ActionResult Edit()
        {
            int id = (int)Session["userID"];
            var result = db.CertUsers.Single(m => m.certUserID == id);
            return View(result);

        }
        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            int id = (int)Session["userID"];
            var result = db.CertUsers.Single(m => m.certUserID == id);
            try
            {
                if (TryUpdateModel(result))
                {
                    db.SaveChanges();
                    return RedirectToAction("MyProfile", new { profileUpdated = 1 });
                }
                return RedirectToAction("MyProfile", new { profileUpdated = 2 });
            }
            catch
            {
                return RedirectToAction("MyProfile", new { profileUpdated = 2 });
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