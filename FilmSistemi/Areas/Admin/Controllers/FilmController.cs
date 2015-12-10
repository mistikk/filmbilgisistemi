using FilmSistemi.Models;
using FilmSistemi.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult FilmEkle()
        {
            return View();
        }
        public ActionResult FilmEkleYeni (FilmModel model)
        {
            //validation eklendi basic modal
            if (true)
            {
                Movies yfilm = new Movies();
                yfilm.MName = model.Movies.MName;
                yfilm.MDirector = model.Movies.MDirector;
                yfilm.MDescription = model.Movies.MDescription;
                yfilm.MMinute = model.Movies.MMinute;
                yfilm.MCountry = model.Movies.MCountry;
                yfilm.MReleaseDate = model.Movies.MReleaseDate;

                db.Movies.Add(yfilm);
                db.SaveChanges();

            }
           return RedirectToAction("Listele");

        }
    }
}

//var model = db.Movies.OrderByDescending(x => x.ID).ToList();
//return View(model);