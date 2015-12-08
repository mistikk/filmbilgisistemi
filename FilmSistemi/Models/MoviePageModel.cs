using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmSistemi.Models
{
    public class MoviePageModel
    {
        public String Movies { get; set; }
        public IEnumerable<Actors> Actors { get; set; }
    }
}