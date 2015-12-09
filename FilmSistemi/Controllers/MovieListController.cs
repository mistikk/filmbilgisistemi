using FilmSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmSistemi.Controllers
{
    public class MovieListController : Controller
    {
        FilmSistemiEntities db = new FilmSistemiEntities();
        // GET: MovieList
        public ActionResult Index()
        {
            List<Object> ActorMovieList = new List<Object>();
            Models.MovieListModel dto = new Models.MovieListModel();
            dto.Movies = db.Movies.Where(x => x.MMinute > 0).OrderByDescending(x => x.MovieId);
            foreach (var item in dto.Movies)
            {
                ActorMovieList.Add(db.ActorMovie.Where(x => x.MovieId == item.MovieId));
            }

            foreach (var item in ActorMovieList)
            {

            }
            
            return View(dto);
        }
    }
}