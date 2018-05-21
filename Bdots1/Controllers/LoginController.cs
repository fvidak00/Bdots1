using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Bdots1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authorize(CertUser userModel)
        {
            using (BDEntities loginDB = new BDEntities())
            {
                var userDetails = loginDB.CertUsers.Where(x => x.username == userModel.username && x.password == userModel.password).FirstOrDefault();

                if(userDetails == null)
                {
                    return View("Index", userModel);
                }
                else
                {
                    Session["userID"] = userDetails.certUserID;
                    return RedirectToAction("Index", "NavigationBar");
                }

            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

    }
}