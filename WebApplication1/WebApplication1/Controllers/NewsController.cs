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
    public class NewsController : Controller
    {
        private familydbEntities db = new familydbEntities();

        // GET: News
        public ActionResult Index()
        {
            return View(db.News.ToList());
        }

        // GET: News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NewsId,Title,Content,ImageURL,InsertDate")] News news, HttpPostedFileBase ImageUpload)
        {
            string filename = "";
            if (ImageUpload != null)
            {
                if (System.IO.File.Exists(Server.MapPath("~/" + news.ImageURL)))
                    System.IO.File.Delete(Server.MapPath("~/" + news.ImageURL));
                // получаем имя файла
                filename = System.IO.Path.GetFileName(ImageUpload.FileName);
                // сохраняем файл в папку Files в проекте
                ImageUpload.SaveAs(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "Content\\news\\" + filename);
                
            }
            news.InsertDate = DateTime.Now;
            news.ImageURL = "/Content/news/" + filename;
            if (ModelState.IsValid)
            {
                news.InsertDate = DateTime.Now;
                db.News.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(news);
        }

        // GET: News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NewsId,Title,Content,ImageURL,InsertDate")] News news, HttpPostedFileBase ImageUpload)
        {
            string filename = "";
            if (ImageUpload != null)
            {
                if (System.IO.File.Exists(Server.MapPath("~/" + news.ImageURL)))
                    System.IO.File.Delete(Server.MapPath("~/" + news.ImageURL));
                // получаем имя файла
                filename = System.IO.Path.GetFileName(ImageUpload.FileName);
                // сохраняем файл в папку Files в проекте
                ImageUpload.SaveAs(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "Content\\news\\" + filename);
                
            }
            news.InsertDate = DateTime.Now;

            news.ImageURL = "/Content/news/" + filename;
            if (ModelState.IsValid)
            {
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);
        }

        // GET: News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.News.Find(id);
            if (System.IO.File.Exists(Server.MapPath("~/" + news.ImageURL)))
                System.IO.File.Delete(Server.MapPath("~/" + news.ImageURL));
            db.News.Remove(news);
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
