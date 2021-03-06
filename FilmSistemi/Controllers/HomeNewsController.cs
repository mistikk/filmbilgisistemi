﻿using FilmSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmSistemi.Controllers
{
    public class HomeNewsController : Controller
    {
        FilmSistemiEntities db = new FilmSistemiEntities();
        Models.NewsModel dto = new NewsModel();


        // GET: News
        public ActionResult Index()
        {

            dto.News = db.News.Where(x => x.NTitle != null).Take(10);

            return View(dto);
        }

        public ActionResult News(int id)
        {
            return View(db.News.FirstOrDefault(x => x.NewsId == id));
        }
    }
}