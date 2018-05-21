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
            BDEntities connection = new BDEntities();
            connection.CertUsers.Add(newCertUser);
            connection.SaveChanges();

          //List<CertUser> ListOfUsers = connection.CertUsers.ToList();

            return Json(newCertUser, JsonRequestBehavior.AllowGet);

           
        }

       
    }
}