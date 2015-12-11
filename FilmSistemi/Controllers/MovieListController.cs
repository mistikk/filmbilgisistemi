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

            // Film-kategori ve Actor-kategori listeleri oluşturuluyor. 
            List<ActorMovie> ActorMovieTemp = new List<ActorMovie>();
            List<ActorMovie> ActorMovieList = new List<ActorMovie>();
            List<MovieCategory> MovieCategoryTemp = new List<MovieCategory>();
            List<MovieCategory> MovieCategoryList = new List<MovieCategory>();
            List<StarListModel> StarsTemp = new List<StarListModel>();
            
            //Veritabanından filmler çekiliyor
            dto.Movies = db.Movies.Where(x => x.MMinute > 0).OrderByDescending(x => x.MovieId);

            //Veritabanından çekilen filmlerin oyuncuları çekilir
            foreach (var item in dto.Movies)
            {
                ActorMovieTemp = db.ActorMovie.Where(x => x.MovieId == item.MovieId).ToList();
                foreach (var actor in ActorMovieTemp)
                {
                    ActorMovieList.Add(actor);
                }

                MovieCategoryTemp = db.MovieCategory.Where(x => x.MovieId == item.MovieId).ToList();
                foreach (var category in MovieCategoryTemp)
                {
                    MovieCategoryList.Add(category);
                }

                //Veritabanından verilen ortalama yıldızı çeker
                StarListModel MovieStar = new StarListModel();
                if (db.Stars.Where(x => x.MovieId == item.MovieId).Count() != 0)
                {
                    MovieStar.MovieId = item.MovieId;
                    MovieStar.StarAvg = (double) db.Stars.Where(x => x.MovieId == item.MovieId).Average(x => x.Star);
                    StarsTemp.Add(MovieStar);
                }
                else
                {
                    MovieStar.MovieId = item.MovieId;
                    MovieStar.StarAvg = 0;
                    StarsTemp.Add(MovieStar);
                }



            }
            dto.ActorMovie = ActorMovieList;
            dto.MovieCategory = MovieCategoryList;
            dto.Stars = StarsTemp;
            return View(dto);
        }
    }
}