using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmSistemi.Models
{
    public class MoviePageModel
    {
        public Movies Movies { get; set; }
        public List<Actors> Actors { get; set; }
        public List<Categories> Categories { get; set; }
        public double Star { get; set; }
        public List<Comments> Comments { get; set; }
        public List<Videos> Videos { get; set; }
        public  News Haber { get; set; }
    }
}