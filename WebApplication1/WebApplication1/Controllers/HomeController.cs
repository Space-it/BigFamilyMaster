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
        public ActionResult News()
        {
            return View();
        }
        public ActionResult Partners()
        {
            return View();
        }

    }
}