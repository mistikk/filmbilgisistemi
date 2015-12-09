using FilmSistemi.Models;
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
    }
}

//var model = db.Movies.OrderByDescending(x => x.ID).ToList();
//return View(model);