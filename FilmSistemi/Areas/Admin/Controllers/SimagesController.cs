using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FilmSistemi.Models;

namespace FilmSistemi.Areas.Admin.Controllers
{
    public class SimagesController : Controller
    {
        private FilmSistemiEntities db = new FilmSistemiEntities();

        // GET: Admin/Simages
        public ActionResult Index()
        {
            return View(db.Simage.ToList());
        }

        // GET: Admin/Simages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Simage simage = db.Simage.Find(id);
            if (simage == null)
            {
                return HttpNotFound();
            }
            return View(simage);
        }

        // GET: Admin/Simages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Simages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sid,İmage,MovieId")] Simage simage)
        {
            if (ModelState.IsValid)
            {
                db.Simage.Add(simage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(simage);
        }

        // GET: Admin/Simages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Simage simage = db.Simage.Find(id);
            if (simage == null)
            {
                return HttpNotFound();
            }
            return View(simage);
        }

        // POST: Admin/Simages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sid,İmage,MovieId")] Simage simage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(simage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(simage);
        }

        // GET: Admin/Simages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Simage simage = db.Simage.Find(id);
            if (simage == null)
            {
                return HttpNotFound();
            }
            return View(simage);
        }

        // POST: Admin/Simages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Simage simage = db.Simage.Find(id);
            db.Simage.Remove(simage);
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
