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
    public class MembersController : Controller
    {
        private familydbEntities db = new familydbEntities();

        // GET: Members
        public ActionResult Index()
        {
            return View(db.Members.ToList());
        }

        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MemberId,Description,ImageURL,Title")] Member member, HttpPostedFileBase ImageUpload)
        {
            if (ImageUpload != null)
            {
                if (System.IO.File.Exists(Server.MapPath("~/" + member.ImageURL)))
                    System.IO.File.Delete(Server.MapPath("~/" + member.ImageURL));
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(ImageUpload.FileName);
                // сохраняем файл в папку Files в проекте
                ImageUpload.SaveAs(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "Content\\partnersImages\\" + fileName);
                member.ImageURL = "/Content/partnersImages/" + fileName;
            }
            else
            {
                member.ImageURL = "/Content/partnersImages/";
            }
            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(member);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MemberId,Description,ImageURL,Title")] Member member, HttpPostedFileBase ImageUpload)
        {
            if (ImageUpload != null)
            {
                if (System.IO.File.Exists(Server.MapPath("~/" + member.ImageURL)))
                    System.IO.File.Delete(Server.MapPath("~/" + member.ImageURL));
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(ImageUpload.FileName);
                // сохраняем файл в папку Files в проекте
                ImageUpload.SaveAs(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "Content\\partnersImages\\" + fileName);
                member.ImageURL = "/Content/partnersImages/" + fileName;
            }

            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
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
