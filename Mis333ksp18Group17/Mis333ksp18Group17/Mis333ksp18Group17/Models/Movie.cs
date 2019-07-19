using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Mis333ksp18Group17.Models
{
    public enum enumMPAARating
    {
        G, PG13, PG, R, NC17, Unrated, All
    }
    public class Movie
    {
        [Key]
        public Int32 MovieID { get; set; }

        public Int32 MovieNum { get; set; }

        [Required]
        [Display(Name = "Title")]
        public String Title { get; set; }

        [Display(Name = "Tagline")]
        public String Tagline { get; set; }

        //[Required]
        //[Display(Name = "Genre")]
        //public String Genre { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "MPAA Rating")]
        public enumMPAARating MPAARating { get; set; }

        [Required]
        [Display(Name = "Actors")]
        public String Actors { get; set; }

        [Required]
        [Display(Name = "Runtime")]
        [Range(typeof(Int32),"0","300")]
        public Int32 Runtime { get; set; }

        [Required]
        [Display(Name = "Overview")]
        public String Overview { get; set; }

        [Display(Name = "Revenue")]
        public Int64 Revenue { get; set; }

        [Display(Name = "Average Customer Rating")]
        public Double AvgRating
        {
            get
            {
                if (Reviews.Count() == 0)
                {
                    return 0;
                }
                else { 
                    return Reviews.Average(r => r.CustomerRating);
                };

            }
        }
        

        public virtual List<Genre> Genres { get; set; }

        public virtual List<Showing> Showings { get; set; }

        public virtual List<Review> Reviews { get; set; }

        public Movie()
        {
            if (Genres == null)
            {
                Genres = new List<Genre>();
            }
            if (Showings == null)
            {
                Showings = new List<Showing>();
            }

            if (Reviews == null)
            {
                Reviews = new List<Review>();
            }
        }
    }
}