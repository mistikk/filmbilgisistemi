using FilmSistemi.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FilmSistemi.Controllers
{
    public class MoviePageController : Controller
    {
        FilmSistemiEntities db = new FilmSistemiEntities();
        Models.MoviePageModel dto = new MoviePageModel();
        // GET: MoviePage
        [HttpGet]
        public ActionResult Index(int id)
        {
            //Yeni Model dan bi nesne oluşturuluyor
            

            List<Actors> ActorList = new List<Actors>();
            List<Categories> CategoryList = new List<Categories>();

            //Veritabanından filmleri çeker
            dto.Movies = db.Movies.FirstOrDefault(x => x.MovieId == id);

            //Veritabanından aktörleri çeker
            var actors = db.ActorMovie.Where(x => x.MovieId == dto.Movies.MovieId);
            foreach (var item in actors)
            {
                ActorList.Add(db.Actors.FirstOrDefault(x => x.ActorId == item.ActorId));
            }
            dto.Actors = ActorList;

            //Veritabanından kategorileri çeker
            var categories = db.MovieCategory.Where(x => x.MovieId == dto.Movies.MovieId);
            foreach (var item in categories)
            {
                CategoryList.Add(db.Categories.FirstOrDefault(x => x.CategoryId == item.CategoryId));
            }
            dto.Categories = CategoryList;

            //Veritabanından verilen ortalama yıldızı çeker
            if (db.Stars.Where(x => x.MovieId == dto.Movies.MovieId).Count() != 0)
            {
                dto.Star = (double)db.Stars.Where(x => x.MovieId == dto.Movies.MovieId).Average(x => x.Star);
            }

            //Veritabanından film için yapılan yorumları çeker
            dto.Comments = db.Comments.Where(x => x.MovieId == dto.Movies.MovieId).ToList();

            //Veritabanından film videolarını getirir
            dto.Videos = db.Videos.Where(x => x.MovieId == dto.Movies.MovieId).ToList();
            return View(dto);
        }
        public JsonResult SaveStar(int id ,int score)
        {
            
            try
            {
                var userID = User.Identity.GetUserId();
                if (userID == null)
                {
                    return Json("Lütfen giriş yapınız!");
                }
                Stars newStar = new Stars();
                newStar.Star = score;
                newStar.MovieId = id;
                newStar.NewUserId = userID;
                db.Stars.Add(newStar);
                return Json(db.SaveChanges());
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public JsonResult SaveComment(int id, string Content)
        {

            var userID = User.Identity.GetUserId();
            if (userID == null)
            {
                return Json("Lütfen giriş yapınız!");
            }
            Comments newComment = new Comments();
            newComment.CContent = Content;
            newComment.NewUserId = userID;
            newComment.UserName = User.Identity.GetUserName();
            newComment.MovieId = id;
            newComment.CDate = DateTime.Today;
            db.Comments.Add(newComment);
            return Json(db.SaveChanges());
        }

    }
}