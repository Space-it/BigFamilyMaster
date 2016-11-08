using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BigFamilyWeb;
using System.Reflection;

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

         void ProcessUpload(dynamic model, HttpPostedFileBase upload,string propertyName,string uploadFolder)
        {
            PropertyInfo UrlProperty = model.GetType().GetProperty(propertyName);

            if (System.IO.File.Exists(Server.MapPath("~/" + UrlProperty.GetValue(model))))
                    System.IO.File.Delete(Server.MapPath("~/" + UrlProperty.GetValue(model)));
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(upload.FileName);
            // сохраняем файл в папку Files в проекте
                upload.SaveAs(string.Format("{0}Content\\{1}\\{2}",System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath, uploadFolder,fileName));
            UrlProperty.SetValue(model, string.Format("/Content/{0}/{1}", uploadFolder,fileName));

        }

        // POST: Sectors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Name,Description,ImageURL,ImaeMobileURL,Contacts,SectorId,PriceURL,MinImageUrl,MinTitle,MinKeywords,LampColor,DecorationURL")] Sector sector, HttpPostedFileBase MinUpload, HttpPostedFileBase PriceUpload, HttpPostedFileBase ImageUpload, HttpPostedFileBase ImageMobileUpload, HttpPostedFileBase ImageDecorationUpload)
        {
            sector.MinImageUrl = "";
            if (MinUpload != null)
                ProcessUpload(sector, MinUpload, "MinImageUrl", "sectorMinImages");

            sector.DecorationURL = "";
            if (ImageDecorationUpload != null)
                ProcessUpload(sector, ImageDecorationUpload, "DecorationURL", "decorations");

            sector.PriceURL = "";
            if (PriceUpload != null)
                ProcessUpload(sector, PriceUpload, "PriceURL", "prices");

            sector.ImageURL = "";
            if (ImageUpload != null)
                ProcessUpload(sector, ImageUpload, "ImageURL", "sectorBigImages");
                
            sector.ImageMobileURL = "";
            if (ImageMobileUpload != null)
                ProcessUpload(sector, ImageMobileUpload, "ImageMobileURL", "sectorBigImages");
            
            if (ModelState.IsValid)
            {
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
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Name,Description,ImageURL,ImageMobileURL,Contacts,SectorId,PriceURL,MinImageUrl,MinTitle,MinKeywords,LampColor,DecorationURL")] Sector sector, HttpPostedFileBase MinUpload, HttpPostedFileBase PriceUpload, HttpPostedFileBase ImageUpload, HttpPostedFileBase ImageMobileUpload, HttpPostedFileBase ImageDecorationUpload)
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
            if (ImageDecorationUpload != null)
            {
                if (System.IO.File.Exists(Server.MapPath("~/" + sector.DecorationURL)))
                    System.IO.File.Delete(Server.MapPath("~/" + sector.DecorationURL));
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(ImageDecorationUpload.FileName);
                // сохраняем файл в папку Files в проекте
                ImageDecorationUpload.SaveAs(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "Content\\decorations\\" + fileName);
                sector.DecorationURL = "/Content/decorations/" + fileName;
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
                sector.ImageMobileURL = "/Content/sectorBigImages/" + fileName;
            }
            if (PriceUpload != null)
            {
                if (System.IO.File.Exists(Server.MapPath("~/" + sector.PriceURL)))
                    System.IO.File.Delete(Server.MapPath("~/" + sector.PriceURL));
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(PriceUpload.FileName);
                // сохраняем файл в папку Files в проекте
                ImageUpload.SaveAs(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "Content\\prices\\" + fileName);
                sector.PriceURL = "/Content/prices/" + fileName;
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
            if (System.IO.File.Exists(Server.MapPath("~/" + sector.DecorationURL)))
                System.IO.File.Delete(Server.MapPath("~/" + sector.DecorationURL));
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
