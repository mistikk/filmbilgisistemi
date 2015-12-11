using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilmSistemi.Models;
namespace FilmSistemi.Areas.Admin.Models
{
    public class FilmModel
    {
        public Movies Movies { get; set; }
        public Actors Actors { get; set; }
       //public MoviePicture Picture { get; set; }
    }
}