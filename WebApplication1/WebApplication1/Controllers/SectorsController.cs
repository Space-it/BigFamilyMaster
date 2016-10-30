using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1;

namespace WebApplication1.Controllers
{
    public class SectorsController : Controller
    {
        private familydbEntities db = new familydbEntities();

        // GET: Sectors
        public ActionResult Index()
        {
            return View(db.Sectors.ToList());
        }

        // GET: Sectors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sector sector = db.Sectors.Find(id);
            if (sector == null)
            {
                return HttpNotFound();
            }
            return View(sector);
        }

        // GET: Sectors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sectors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description,ImageURL,Contacts,SectorId,PriceURL,MinImageUrl,MinTitle,MinKeywords,LampColor")] Sector sector, HttpPostedFileBase MinUpload, HttpPostedFileBase PriceUpload, HttpPostedFileBase ImageUpload)
        {
            // получаем имя файла
            string fileName = System.IO.Path.GetFileName(MinUpload.FileName);
            // сохраняем файл в папку Files в проекте
            MinUpload.SaveAs(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "Content\\images\\" + fileName);

            // получаем имя файла
            string fileName1 = System.IO.Path.GetFileName(PriceUpload.FileName);
            // сохраняем файл в папку Files в проекте
            PriceUpload.SaveAs(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "Content\\prices\\" + fileName1);

            // получаем имя файла
            string fileName2 = System.IO.Path.GetFileName(ImageUpload.FileName);
            // сохраняем файл в папку Files в проекте
            ImageUpload.SaveAs(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "Content\\images\\" + fileName2);

            if (ModelState.IsValid)
            {
                sector.MinImageUrl = "/Content/images/" + fileName;
                sector.PriceURL = "/Content/prices/" + fileName1;
                sector.ImageURL = "/Content/images/" + fileName2;
                db.Sectors.Add(sector);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sector);
        }

        // GET: Sectors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sector sector = db.Sectors.Find(id);
            if (sector == null)
            {
                return HttpNotFound();
            }
            return View(sector);
        }

        // POST: Sectors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,Description,ImageURL,Contacts,SectorId,PriceURL,MinImageUrl,MinTitle,MinKeywords,LampColor")] Sector sector, HttpPostedFileBase MinUpload, HttpPostedFileBase PriceUpload, HttpPostedFileBase ImageUpload)
        {
            if (MinUpload != null)
            {
                System.IO.File.Delete(Server.MapPath("~/" + sector.MinImageUrl));
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(MinUpload.FileName);
                // сохраняем файл в папку Files в проекте
                MinUpload.SaveAs(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "Content\\images\\" + fileName);
                sector.MinImageUrl = "/Content/images" + fileName;
            }
            if (ImageUpload != null)
            {
                System.IO.File.Delete(Server.MapPath("~/" + sector.ImageURL));
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(ImageUpload.FileName);
                // сохраняем файл в папку Files в проекте
                ImageUpload.SaveAs(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "Content\\images\\" + fileName);
                sector.ImageURL = "/Content/images" + fileName;
            }
            if (PriceUpload != null)
            {
                System.IO.File.Delete(Server.MapPath("~/" + sector.PriceURL));
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(PriceUpload.FileName);
                // сохраняем файл в папку Files в проекте
                ImageUpload.SaveAs(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "Content\\prices\\" + fileName);
                sector.ImageURL = "/Content/prices" + fileName;
            }
            if (ModelState.IsValid)
            {
                db.Entry(sector).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sector);
        }

        // GET: Sectors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sector sector = db.Sectors.Find(id);
            if (sector == null)
            {
                return HttpNotFound();
            }
            return View(sector);
        }

        // POST: Sectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sector sector = db.Sectors.Find(id);
            db.Sectors.Remove(sector);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
