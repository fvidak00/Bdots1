using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bdots1.Controllers
{
    public class MiscController : Controller
    {
        // GET: Misc
        private BDEntities db = new BDEntities();

    //    public ActionResult VideoPlayer(int? id)

        public ActionResult VideoPlayer()
        {
            //int asd = (int)id;
            var result = from v in db.Videos
                         //where v.videoID == id
                         select v;
            var rf= result.FirstOrDefault();
            return View(rf);
            
        }
        
    }
}