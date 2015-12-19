using FilmSistemi.Models;
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

            //categorisi movi aydi le aynı olan categorymoviden siliyor
            //mal diilsen anlarsın m*
            if (category == null)
            {
                var silcat = db.MovieCategory.Where(n => n.MovieId == id);
                foreach (var item in silcat)
                {
                    db.MovieCategory.Remove(item);
                }
            }

            if (actor == null)
            {
                var silid = db.ActorMovie.Where(n => n.MovieId == id);
                foreach (var item in silid)
                {

                    db.ActorMovie.Remove(item);

                }

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
        public ActionResult FilmEkle(FilmModel model, HttpPostedFileBase pic)
        {
            Actors artiz = new Actors();
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


                ActorMovie actormovie = new ActorMovie();
                if (actormovie == null)
                {


                    //var actorName = actormovie.Actors.ActorName;
                    foreach (var item in names)
                    {
                        //var ugur = item;
                        //actorName = ugur;
                        //actormovie.Actors.ActorName = ugur;

                        //actormovie.MovieId = r.MovieId;
                        var iteminactor = db.Actors.Add(new Actors { ActorName = item });
                        db.ActorMovie.Add(new ActorMovie { MovieId = r.MovieId, ActorId = iteminactor.ActorId });
                        db.SaveChanges();
                    }

                }

                //for (int i = 0; i < names.Length; i++)
                //{
                //    db.Actors.Add(new Actors() { ActorName = names[i], MovieId = r.MovieId });
                //    db.SaveChanges();
                //}

                /*  MoviePicture picture = new MoviePicture();
              picture.Picture = model.Picture.Picture;
              db.MoviePicture.Add(picture); */

            }


            return RedirectToAction("Listele");

        }



    }


}

//var model = db.Movies.OrderByDescending(x => x.ID).ToList();
//return View(model);

