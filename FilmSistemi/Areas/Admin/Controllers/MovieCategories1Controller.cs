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
    public class MovieCategories1Controller : Controller
    {
        private FilmSistemiEntities db = new FilmSistemiEntities();

        // GET: Admin/MovieCategories1
        public ActionResult Index()
        {
            var movieCategory = db.MovieCategory.Include(m => m.Categories).Include(m => m.Movies);
            return View(movieCategory.ToList());
        }

        // GET: Admin/MovieCategories1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieCategory movieCategory = db.MovieCategory.Find(id);
            if (movieCategory == null)
            {
                return HttpNotFound();
            }
            return View(movieCategory);
        }

        // GET: Admin/MovieCategories1/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CName");
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "MName");
            return View();
        }

        // POST: Admin/MovieCategories1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieCategoryId,MovieId,CategoryId")] MovieCategory movieCategory)
        {
            if (ModelState.IsValid)
            {
                db.MovieCategory.Add(movieCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CName", movieCategory.CategoryId);
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "MName", movieCategory.MovieId);
            return View(movieCategory);
        }

        // GET: Admin/MovieCategories1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieCategory movieCategory = db.MovieCategory.Find(id);
            if (movieCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CName", movieCategory.CategoryId);
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "MName", movieCategory.MovieId);
            return View(movieCategory);
        }

        // POST: Admin/MovieCategories1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieCategoryId,MovieId,CategoryId")] MovieCategory movieCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movieCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CName", movieCategory.CategoryId);
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "MName", movieCategory.MovieId);
            return View(movieCategory);
        }

        // GET: Admin/MovieCategories1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieCategory movieCategory = db.MovieCategory.Find(id);
            if (movieCategory == null)
            {
                return HttpNotFound();
            }
            return View(movieCategory);
        }

        // POST: Admin/MovieCategories1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovieCategory movieCategory = db.MovieCategory.Find(id);
            db.MovieCategory.Remove(movieCategory);
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
