using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mis333ksp18Group17.Models
{
    public class Genre
    {
        public Int32 GenreID { get; set; }

        public String Name { get; set; }

        public virtual List<Movie> Movies { get; set; }

        public Genre()
        {
            if (Movies == null)
            {
                Movies = new List<Movie>();
            }
        }
    }
}