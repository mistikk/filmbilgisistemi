using FilmSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmSistemi.Controllers
{
    public class NewsController : Controller
    {
        FilmSistemiEntities db = new FilmSistemiEntities();


        // GET: News
        public ActionResult Index()
        {
            return View();
        }
    }
}