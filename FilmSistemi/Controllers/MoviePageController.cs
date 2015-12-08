using FilmSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmSistemi.Controllers
{
    public class MoviePageController : Controller
    {
        FilmSistemiEntities db = new FilmSistemiEntities();
        // GET: MoviePage
        [HttpGet]
        public ActionResult Index(int id)
        {
            Models.MoviePageModel dto = new MoviePageModel();
            List<Object> list = new List<Object>();
            //db.Movies.Find(id);
            dto.Movies = db.Movies.FirstOrDefault(x => x.MovieId == id);
            var model = db.ActorMovie.Where(x => x.MovieId == movie.MovieId);
            foreach (var item in model)
            {
                list.Add(db.Actors.FirstOrDefault(x => x.ActorId == item.ActorId));
            }
            
            return View(new {
                movie = movie,
                actors = list
            });
        }

    }
}