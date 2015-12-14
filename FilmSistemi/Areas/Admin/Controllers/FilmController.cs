using FilmSistemi.Models;
using FilmSistemi.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace FilmSistemi.Areas.Admin.Controllers
{
    public class FilmController : Controller
    {
        // Veri tabanını tanımladım
        FilmSistemiEntities db = new FilmSistemiEntities();
        // GET: Admin/Film
        public ActionResult Listele()
        {
            //var idgetir =  db.Movies.FirstOrDefault(x=> x.MovieId == 1);
            //var idgetir = db.Movies.ToList();
            // return View(idgetir);
            var model = db.Movies.OrderByDescending(x => x.MovieId).ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult FilmEkle()
        {
            return View();
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