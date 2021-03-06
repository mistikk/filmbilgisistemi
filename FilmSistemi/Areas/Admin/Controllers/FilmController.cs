﻿using FilmSistemi.Models;
using FilmSistemi.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net;
using System.Data.Entity;

namespace FilmSistemi.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class FilmController : Controller
    {
        // Veri tabanını tanımladım
        FilmSistemiEntities db = new FilmSistemiEntities();
        // GET: Admin/Film
        public ActionResult Listele()
        {

            var model = db.Movies.OrderByDescending(x => x.MovieId).ToList();

            return View(model);
        }

        [HttpGet]
        public ActionResult FilmEkle()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CName");

            return View();
        }


        // EDİTTTTTTTTTTTTTTTTTTTTT BAŞ
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movies movies = db.Movies.Find(id);
            if (movies == null)
            {
                return HttpNotFound();
            }
            return View(movies);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieId,MName,MDescription,MMinute,MReleaseDate,MCountry,MDirector,MBanner")] Movies movies)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movies).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Listele");
            }
            return View(movies);
        }
        // EDİTTTTTTTTTTTTTTTTTTTTT SON



        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movies movies = db.Movies.Find(id);
            if (movies == null)
            {
                return RedirectToAction("Listele");
            }
            return View(movies);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movies movies = db.Movies.Find(id);
            db.Movies.Remove(movies);
            ActorMovie actor = new ActorMovie();
            MovieCategory category = new MovieCategory();

            
            if (category != null)
            {
                var silcat = db.MovieCategory.Where(n => n.MovieId == id);
                foreach (var item in silcat)
                {
                    db.MovieCategory.Remove(item);
                }
            }

            if (actor != null)
            {
                var silid = db.ActorMovie.Where(n => n.MovieId == id);
                foreach (var item in silid)
                {

                    db.ActorMovie.Remove(item);

                }

            }
            var DeleteStar = db.Stars.Where(n => n.MovieId == id);
            foreach (var item in DeleteStar)
            {

                db.Stars.Remove(item);

            }
            var DeleteComment = db.Comments.Where(n => n.MovieId == id);
            foreach (var item in DeleteComment)
            {

                db.Comments.Remove(item);

            } 
            var DeleteSlider = db.Simage.Where(n => n.MovieId == id);
            foreach (var item in DeleteSlider)
            {

                db.Simage.Remove(item);

            }
            db.SaveChanges();
            return RedirectToAction("Listele");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }




        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult FilmEkle(FilmModel model, HttpPostedFileBase pic, int CategoryId)
        {/*
            string path = Server.MapPath("~/Content/moviepic");
            if (System.IO.File.Exists(path))
            {

                for (int i = 0; i < Request.Files.Count; i++)
                {

                    Request.Files[i].SaveAs(string.Format("{0}\\{1}", path, Request.Files[i].FileName));
                }
            }
            */
            //validation eklendi basic modal
            if (true)
            {
                MemoryStream memoryStream = pic.InputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    pic.InputStream.CopyTo(memoryStream);
                }

                Movies yfilm = new Movies();

                yfilm.MName = model.Movies.MName;
                yfilm.MDirector = model.Movies.MDirector;
                yfilm.MDescription = model.Movies.MDescription;
                yfilm.MMinute = model.Movies.MMinute;
                yfilm.MCountry = model.Movies.MCountry;
                yfilm.MReleaseDate = model.Movies.MReleaseDate;
                yfilm.MBanner = memoryStream.ToArray();

                var r = db.Movies.Add(yfilm);
                db.SaveChanges();
                var names = model.Actors.ActorName.Split(',');

                var catid = CategoryId;
                if (catid > 0)
                {

                    db.MovieCategory.Add(new MovieCategory { MovieId = r.MovieId, CategoryId = catid });
                    db.SaveChanges();
                }

                ActorMovie actormovie = new ActorMovie();
                if (actormovie != null)
                {
                    //var actorName = actormovie.Actors.ActorName;
                    foreach (var item in names)
                    {
                        var iteminactor = db.Actors.Add(new Actors { ActorName = item });
                        db.ActorMovie.Add(new ActorMovie { MovieId = r.MovieId, ActorId = iteminactor.ActorId });
                        db.SaveChanges();
                    }
                }

            }


            return RedirectToAction("Listele");
        }



    }


}
