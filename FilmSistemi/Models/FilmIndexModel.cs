using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmSistemi.Models
{
    public class FilmIndexModel
    {
        public List<Movies> BestMovies { get; set; }
        public List<Movies> LastMovies { get; set; }
        public int MyProperty { get; set; }
    }
}