using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigFamilyWeb.Controllers
{
    public class HomeController : Controller
    {
        private familydbEntities db = new familydbEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Contacts()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View(db.Sectors.ToList());
        }

        public ActionResult Sector(int id)
        {
            List<Sector> tempList = null;
            if (db.Sectors.Count() != 0)
                tempList = db.Sectors.ToList();
            
                if (id >= tempList.Count)
                    id = 0;
                if (id < 0)
                    id = tempList.Count - 1;

                ViewBag.SectorIndex = id;
            return View(tempList[id]);

        }
        public ActionResult News()
        {
            var News = db.News.ToList();
            return View(News);
        }
        public ActionResult Partners()
        {
            return View();
        }

    }
}