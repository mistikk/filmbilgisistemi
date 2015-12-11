using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmSistemi.Models
{
    public class MovieListModel
    {
        public IEnumerable<Movies> Movies { get; set; }

        public List<ActorMovie> ActorMovie { get; set; }

        public List<MovieCategory> MovieCategory { get; set; }

        public IEnumerable<StarListModel> Stars { get; set; }

        public List<Comments> Comments { get; set; }

        
    }

}