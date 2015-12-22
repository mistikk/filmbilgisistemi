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
    public class ActorMoviesController : Controller
    {
        private FilmSistemiEntities db = new FilmSistemiEntities();

        // GET: Admin/ActorMovies
        public ActionResult Index()
        {
            var actorMovie = db.ActorMovie.Include(a => a.Actors).Include(a => a.Movies);
            return View(actorMovie.ToList());
        }

        // GET: Admin/ActorMovies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActorMovie actorMovie = db.ActorMovie.Find(id);
            if (actorMovie == null)
            {
                return HttpNotFound();
            }
            return View(actorMovie);
        }

        // GET: Admin/ActorMovies/Create
        public ActionResult Create()
        {
            ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "ActorName");
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "MName");
            return View();
        }

        // POST: Admin/ActorMovies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActorMovieId,ActorId,MovieId")] ActorMovie actorMovie)
        {
            if (ModelState.IsValid)
            {
                db.ActorMovie.Add(actorMovie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "ActorName", actorMovie.ActorId);
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "MName", actorMovie.MovieId);
            return View(actorMovie);
        }

        // GET: Admin/ActorMovies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActorMovie actorMovie = db.ActorMovie.Find(id);
            if (actorMovie == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "ActorName", actorMovie.ActorId);
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "MName", actorMovie.MovieId);
            return View(actorMovie);
        }

        // POST: Admin/ActorMovies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActorMovieId,ActorId,MovieId")] ActorMovie actorMovie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actorMovie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "ActorName", actorMovie.ActorId);
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "MName", actorMovie.MovieId);
            return View(actorMovie);
        }

        // GET: Admin/ActorMovies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActorMovie actorMovie = db.ActorMovie.Find(id);
            if (actorMovie == null)
            {
                return HttpNotFound();
            }
            return View(actorMovie);
        }

        // POST: Admin/ActorMovies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActorMovie actorMovie = db.ActorMovie.Find(id);
            db.ActorMovie.Remove(actorMovie);
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
