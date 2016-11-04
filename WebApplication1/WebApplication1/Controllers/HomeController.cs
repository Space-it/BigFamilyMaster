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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Contact contact)
        {
            contact.Adress1 = "Не указано";
            contact.Company = "Не указано";
            contact.IsNew = true;
            contact.LastName = "Не указано";
            contact.Phone1 = "Не указано";
            contact.Phone2 = "Не указано";
            contact.Surname = "Не указано";
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return PartialView("SendStatus", "Отправлено!");
            }
            return PartialView("SendStatus", "Не отправлено!");
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
            return View(db.News.ToList());
        }
        public ActionResult Partners()
        {
            return View();
        }

    }
}