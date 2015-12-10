using FilmSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmSistemi.Controllers
{
    public class HomeController : Controller
    {
        FilmSistemiEntities db = new FilmSistemiEntities();
        public ActionResult Index()
        {
            
            return View();
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