using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Bdots1.Controllers
{
   

    public class RegistrationController : Controller
    {
        public ActionResult Registration()
        {
            ViewBag.Message = "Registration";
            return View();
        }

        [HttpPost]

        public JsonResult SaveUser(CertUser newCertUser)
        {
            int state;
            BDEntities connection = new BDEntities();
            // string poruka = "amen chao";
            List<CertUser> ListOfUsers = connection.CertUsers.ToList();

            foreach (CertUser d in ListOfUsers)
            {
                if (newCertUser.email == d.email)
                {
                    state = 2;
                    return Json(state, JsonRequestBehavior.AllowGet);
                }
                else if (newCertUser.username == d.username)
                {
                    state = 1;
                    return Json(state, JsonRequestBehavior.AllowGet);
                }
               
            }

            newCertUser.balance = 0;
            connection.CertUsers.Add(newCertUser);
            connection.SaveChanges();

            state = 0;
            return Json(state, JsonRequestBehavior.AllowGet);
        }

       
    }
}