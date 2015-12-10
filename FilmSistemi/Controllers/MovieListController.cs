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
            //Yeni Model dan bi nesne oluşturuluyor
            Models.MovieListModel dto = new Models.MovieListModel();

            List<ActorMovie> ActorMovieList = new List<ActorMovie>();

            //Veritabanından filmler çekiliyor
            dto.Movies = db.Movies.Where(x => x.MMinute > 0).OrderByDescending(x => x.MovieId);

            //Veritabanından çekilen filmlerin oyuncuları çekilir
            foreach (var item in dto.Movies)
            {
                ActorMovieList = db.ActorMovie.Where(x => x.MovieId == item.MovieId).ToList();
            }
            dto.ActorMovie = ActorMovieList;
            
            return View(dto);
        }
    }
}