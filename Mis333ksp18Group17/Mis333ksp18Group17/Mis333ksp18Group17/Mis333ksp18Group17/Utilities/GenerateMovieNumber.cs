using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mis333ksp18Group17.DAL;


namespace Mis333ksp18Group17.Utilities
{
    public static class GenerateMovieNumber

    {
        public static Int32 GetNextMovieNumber()
        {
            AppDbContext db = new AppDbContext();

            Int32 intMaxMovieNumber;
            Int32 intNextMovieNumber;

            if (db.Movies.Count() == 0)
            {
                intMaxMovieNumber = 5000;
            }
            else
            {
                intMaxMovieNumber = db.Movies.Max(c => c.MovieNum);
            }

            intNextMovieNumber = intMaxMovieNumber + 1;
            return intNextMovieNumber;
        }
    }
}