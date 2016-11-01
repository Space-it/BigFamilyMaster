using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BigFamilyWeb;

namespace BigFamilyWeb.Controllers
{
    public class SectorsController : Controller
    {
        private familydbEntities db = new familydbEntities();
        private string Message;
        public ActionResult Error()
        {
            return View();
        }

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
        public ActionResult Create([Bind(Include = "Name,Description,ImageURL,ImaeMobileURL,Contacts,SectorId,PriceURL,MinImageUrl,MinTitle,MinKeywords,LampColor")] Sector sector, HttpPostedFileBase MinUpload, HttpPostedFileBase PriceUpload, HttpPostedFileBase ImageUpload, HttpPostedFileBase ImageMobileUpload)
        {
            string fileName = string.Empty;
            string fileName1 = string.Empty;
            string fileName2 = string.Empty;
            string fileName3 = string.Empty;
            if (MinUpload != null)
            {
                if (System.IO.File.Exists(Server.MapPath("~/" + sector.MinImageUrl)))
                    System.IO.File.Delete(Server.MapPath("~/" + sector.MinImageUrl));
                // получаем имя файла
                fileName = System.IO.Path.GetFileName(MinUpload.FileName);
                // сохраняем файл в папку Files в проекте
                MinUpload.SaveAs(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "Content\\sectorMinImages\\" + fileName);
            }
            if (PriceUpload != null)
            {
                if (System.IO.File.Exists(Server.MapPath("~/" + sector.PriceURL)))
                    System.IO.File.Delete(Server.MapPath("~/" + sector.PriceURL));

                // получаем имя файла
                fileName1 = System.IO.Path.GetFileName(PriceUpload.FileName);
                // сохраняем файл в папку Files в проекте
                PriceUpload.SaveAs(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "Content\\prices\\" + fileName1);
            }
            if (ImageUpload != null)
            {
                if (System.IO.File.Exists(Server.MapPath("~/" + sector.ImageURL)))
                    System.IO.File.Delete(Server.MapPath("~/" + sector.ImageURL));
                // получаем имя файла
                fileName2 = System.IO.Path.GetFileName(ImageUpload.FileName);
                // сохраняем файл в папку Files в проекте
                ImageUpload.SaveAs(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "Content\\sectorBigImages\\" + fileName2);
            }
            if (ImageMobileUpload != null)
            {
                if (System.IO.File.Exists(Server.MapPath("~/" + sector.ImageMobileURL)))
                    System.IO.File.Delete(Server.MapPath("~/" + sector.ImageMobileURL));
                // получаем имя файла
                fileName3 = System.IO.Path.GetFileName(ImageMobileUpload.FileName);
                // сохраняем файл в папку Files в проекте
                ImageMobileUpload.SaveAs(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "Content\\sectorBigImages\\" + fileName2);
            }

            sector.MinImageUrl = "/Content/sectorMinImages/" + fileName;
            sector.PriceURL = "/Content/prices/" + fileName1;
            sector.ImageURL = "/Content/sectorBigImages/" + fileName2;
            if (ModelState.IsValid)
            {
                sector.MinImageUrl = "/Content/sectorMinImages/" + fileName;
                sector.PriceURL = "/Content/prices/" + fileName1;
                sector.ImageURL = "/Content/sectorBigImages/" + fileName2;
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
        public ActionResult Edit([Bind(Include = "Name,Description,ImageURL,ImaeMobileURL,Contacts,SectorId,PriceURL,MinImageUrl,MinTitle,MinKeywords,LampColor")] Sector sector, HttpPostedFileBase MinUpload, HttpPostedFileBase PriceUpload, HttpPostedFileBase ImageUpload, HttpPostedFileBase ImageMobileUpload)
        {
            if (MinUpload != null)
            {
                if (System.IO.File.Exists(Server.MapPath("~/" + sector.MinImageUrl)))
                    System.IO.File.Delete(Server.MapPath("~/" + sector.MinImageUrl));

                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(MinUpload.FileName);
                // сохраняем файл в папку Files в проекте
                MinUpload.SaveAs(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "Content\\sectorMinImages\\" + fileName);
                sector.MinImageUrl = "/Content/sectorMinImages/" + fileName;
            }
            if (ImageUpload != null)
            {
                if (System.IO.File.Exists(Server.MapPath("~/" + sector.ImageURL)))
                    System.IO.File.Delete(Server.MapPath("~/" + sector.ImageURL));
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(ImageUpload.FileName);
                // сохраняем файл в папку Files в проекте
                ImageUpload.SaveAs(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "Content\\sectorBigImages\\" + fileName);
                sector.ImageURL = "/Content/sectorBigImages/" + fileName;
            }
            if (ImageMobileUpload != null)
            {
                if (System.IO.File.Exists(Server.MapPath("~/" + sector.ImageMobileURL)))
                    System.IO.File.Delete(Server.MapPath("~/" + sector.ImageMobileURL));
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(ImageMobileUpload.FileName);
                // сохраняем файл в папку Files в проекте
                ImageMobileUpload.SaveAs(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "Content\\sectorBigImages\\" + fileName);
                sector.ImageURL = "/Content/sectorBigImages/" + fileName;
            }
            if (PriceUpload != null)
            {
                if (System.IO.File.Exists(Server.MapPath("~/" + sector.PriceURL)))
                    System.IO.File.Delete(Server.MapPath("~/" + sector.PriceURL));
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(PriceUpload.FileName);
                // сохраняем файл в папку Files в проекте
                ImageUpload.SaveAs(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "Content\\prices\\" + fileName);
                sector.ImageURL = "/Content/prices/" + fileName;
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
            if (System.IO.File.Exists(Server.MapPath("~/" + sector.MinImageUrl)))
                System.IO.File.Delete(Server.MapPath("~/" + sector.MinImageUrl));
            if (System.IO.File.Exists(Server.MapPath("~/" + sector.ImageURL)))
                System.IO.File.Delete(Server.MapPath("~/" + sector.ImageURL));
            if (System.IO.File.Exists(Server.MapPath("~/" + sector.ImageMobileURL)))
                System.IO.File.Delete(Server.MapPath("~/" + sector.ImageMobileURL));
            if (System.IO.File.Exists(Server.MapPath("~/" + sector.PriceURL)))
                System.IO.File.Delete(Server.MapPath("~/" + sector.PriceURL));
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
