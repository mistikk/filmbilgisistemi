using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmSistemi.Controllers
{
    public class MoviePageController : Controller
    {
        // GET: MoviePage
        public ActionResult Index()
        {
            return View();
        }
    }
}