using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmSistemi.Models
{
    public class MovieListModel
    {
        public IEnumerable<Movies> Movies { get; set; }

        public List<Actors> Actors { get; set; }
    }

}