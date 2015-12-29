using FilmSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmSistemi.Controllers
{
    [Language]
    public class HomeController : Controller
    {
        FilmSistemiEntities db = new FilmSistemiEntities();
        [HttpGet]
        public ActionResult Index()
        {
            FilmIndexModel dto = new FilmIndexModel();
            dto.LastMovies = db.Movies.OrderByDescending(x => x.MovieId).Take(8).ToList();
            dto.BestMovies = db.Movies.OrderByDescending(x => x.Stars.Average(y => y.Star)).Take(6).ToList();
            dto.Slider = db.Simage.OrderBy(x => x.Sid).Take(4).ToList();
            return View(dto);
        }
        [ChildActionOnly]
        public ActionResult _Slider()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult moviepage()
        {

            return View();
        }
        public ActionResult movielist()
        {
            var movies = db.Movies.Where(x => x.MMinute > 0).OrderByDescending(x => x.MovieId);
            return View(movies);
        }
        public ActionResult news()
        {

            return View();
        }
        public ActionResult singlenews()
        {

            return View();
        }


    }
}