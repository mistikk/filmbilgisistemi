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
    public class SliderimgsController : Controller
    {
        private FilmSistemiEntities db = new FilmSistemiEntities();

        // GET: Admin/Sliderimgs
        public ActionResult Index()
        {
            return View(db.Sliderimg.ToList());
        }

        // GET: Admin/Sliderimgs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sliderimg sliderimg = db.Sliderimg.Find(id);
            if (sliderimg == null)
            {
                return HttpNotFound();
            }
            return View(sliderimg);
        }

        // GET: Admin/Sliderimgs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sliderimgs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SliderId,Picture,MovieId")] Sliderimg sliderimg)
        {
            if (ModelState.IsValid)
            {
                db.Sliderimg.Add(sliderimg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sliderimg);
        }

        // GET: Admin/Sliderimgs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sliderimg sliderimg = db.Sliderimg.Find(id);
            if (sliderimg == null)
            {
                return HttpNotFound();
            }
            return View(sliderimg);
        }

        // POST: Admin/Sliderimgs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SliderId,Picture,MovieId")] Sliderimg sliderimg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sliderimg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sliderimg);
        }

        // GET: Admin/Sliderimgs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sliderimg sliderimg = db.Sliderimg.Find(id);
            if (sliderimg == null)
            {
                return HttpNotFound();
            }
            return View(sliderimg);
        }

        // POST: Admin/Sliderimgs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sliderimg sliderimg = db.Sliderimg.Find(id);
            db.Sliderimg.Remove(sliderimg);
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
