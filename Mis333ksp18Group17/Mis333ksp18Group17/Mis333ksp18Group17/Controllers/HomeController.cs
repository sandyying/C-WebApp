using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mis333ksp18Group17.Models;
using Mis333ksp18Group17.DAL;
using System.Net;
public enum StarRank { GreaterThan, LessThan, Equal }
    public enum Classification { Before,After, All}
    public enum enumMPAA
    {
        G, PG13, PG, R, NC17, Unrated, All
    }
namespace Mis333ksp18Group17.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private AppDbContext db = new AppDbContext();


        // GET: Home
        public ActionResult Index(String SearchString)
        {

            List<Movie> SelectedMovies = new List<Movie>();
            var query = from r in db.Movies
                        select r;
            query.OrderBy(r => r.MovieNum);

            if (SearchString != null)
            {
                query = query.Where(r => r.Title.Contains(SearchString));


            }

            SelectedMovies = query.ToList();
            SelectedMovies.OrderBy(r => r.MovieNum);
            ViewBag.TotalMovies = db.Movies.Count();
            ViewBag.SelectedMovies = SelectedMovies.Count();
            return View("Index", SelectedMovies);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        public ActionResult DetailedSearch()
        {
            ViewBag.AllGenres = GetAllGenres();
            return View();
        }

        public ActionResult DisplaySearchResults(String strTitle, String strTagline, int[] enumGenres, DateTime? SelectedReleaseYear, Classification SelectedClass, enumMPAA Rating,
            String strActor, String CustomerRating, StarRank CustomerRatingRank, String RunTime, StarRank RunTimeG, DateTime? SelectedShowTime, Classification SelectedClass1)
        {
            var query = from r in db.Movies
                        select r;
            if (strTitle != null)
            {
                query = query.Where(r => r.Title.Contains(strTitle));
            }
            if (strTagline != null)
            {
                query = query.Where(r => r.Tagline.Contains(strTagline));
            }

            if (enumGenres != null)
            {
                foreach(int i in enumGenres)
                {                     
                      query = query.Where(r => r.Genres.Any(g => g.GenreID == i));
                }
                    
            }



            if (CustomerRating != null && CustomerRating != "")
            {
                Double decCustomerRating;
                try
                {
                    decCustomerRating = Convert.ToDouble(CustomerRating);
                    switch (CustomerRatingRank)
                    {
                        case StarRank.GreaterThan:

                            query = query.Where(r => r.Reviews.Average(c => c.CustomerRating) > decCustomerRating);

                            break;
                        case StarRank.LessThan:

                            query = query.Where(r => r.Reviews.Average(c => c.CustomerRating) < decCustomerRating);

                            break;
                        case StarRank.Equal:

                            query = query.Where(r => r.Reviews.Average(c => c.CustomerRating) == decCustomerRating);

                            break;

                    }
                }
                catch
                {
                    ViewBag.Message = "You must enter a number to search average customer rating";
                    ViewBag.AllGenres = GetAllGenres();
                    return View("DetailedSearch");
                }

            }



            if (SelectedReleaseYear != null)
            {

                switch (SelectedClass)
                {
                    case Classification.After:

                        query = query.Where(r => r.ReleaseDate >= SelectedReleaseYear);

                        break;
                    case Classification.Before:

                        query = query.Where(r => r.ReleaseDate < SelectedReleaseYear);

                        break;
                    //case Classification.Equal:

                    //    query = query.Where(r => r.ReleaseDate == SelectedReleaseYear);

                    //    break;

                }
            }


           
            if (strActor != null)
            {
                query = query.Where(r => r.Actors.Contains(strActor));
            }

            switch (Rating)
            {
                case enumMPAA.Unrated:

                    query = query.Where(r => r.MPAARating == enumMPAARating.Unrated);

                    break;
                case enumMPAA.R:

                    query = query.Where(r => r.MPAARating == enumMPAARating.R);

                    break;
                case enumMPAA.PG:

                    query = query.Where(r => r.MPAARating == enumMPAARating.PG);

                    break;
                case enumMPAA.PG13:

                    query = query.Where(r => r.MPAARating == enumMPAARating.PG13);

                    break;
                case enumMPAA.G:

                    query = query.Where(r => r.MPAARating == enumMPAARating.G);

                    break;
                case enumMPAA.NC17:

                    query = query.Where(r => r.MPAARating == enumMPAARating.NC17);

                    break;
                default:
                    break;

            }

            if (RunTime != null && RunTime != "")
            {
                Int32 intRunTime;
                try
                {
                    intRunTime = Convert.ToInt32(RunTime);
                    switch (RunTimeG)
                    {
                        case StarRank.GreaterThan:

                            query = query.Where(r => r.Runtime >= intRunTime);

                            break;                     
                        case StarRank.LessThan:

                            query = query.Where(r => r.Runtime < intRunTime);

                            break;
                        case StarRank.Equal:

                            query = query.Where(r => r.Runtime == intRunTime);

                            break;
                    }
                }
                catch
                {
                    ViewBag.Message1 = "You must enter a number to search run time";
                    ViewBag.AllGenres = GetAllGenres();
                    return View("DetailedSearch");
                }

            }

            if (SelectedShowTime != null)
            {

                switch (SelectedClass1)
                {
                    case Classification.After:

                        query = query.Where(r => r.Showings.Any(c => c.Date >= SelectedShowTime));

                        break;
                    case Classification.Before:

                        query = query.Where(r => r.Showings.Any(c => c.Date< SelectedShowTime));

                        break;
                    //case Classification.Equal:

                    //    query = query.Where(r => r.Showings.Any(c => c.StartTime == SelectedShowTime));

                    //    break;

                }
            }

            List<Movie> MoviesToDisplay = query.ToList();
            MoviesToDisplay.OrderBy(r => r.MovieNum);
            ViewBag.TotalMovies = db.Movies.Count();
            ViewBag.SelectedMovies = MoviesToDisplay.Count();
            return View("Index", MoviesToDisplay);
        }

        public MultiSelectList GetAllGenres()
        {
            List<Genre> Genres = db.Genres.ToList();
            
            MultiSelectList AllGenres = new SelectList(Genres.OrderBy(m => m.GenreID), "GenreID", "Name");
            return AllGenres;
        }

        //public SelectList GetAllMPAA()
        //{
        //    SelectList AllMPAA = new SelectList(Enum.GetValues(typeof(enumMPAARating)).Cast<enumMPAARating>().Select(v => new SelectListItem)
        //    {
        //        Text = v.ToString(),
        //        Value = ((int)v).ToString()

        //    }).ToList(),"Value","Text");

        //    return AllMPAA;
        //}

      




    }
}