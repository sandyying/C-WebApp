using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;

using System.Web.Mvc;
using Mis333ksp18Group17.DAL;
using Mis333ksp18Group17.Models;

namespace Mis333ksp18Group17.Controllers
{
    public class ShowingsController : Controller
    {
        public enum Pending { Yes, No }
        private AppDbContext db = new AppDbContext();

        // GET: Showings
        public ActionResult Index(String MovieName)
        {
            List<Showing> SelectedShowings = new List<Showing>();

            var query = from s in db.Showings
                        select s;
            query = query.OrderBy(s => s.Location).ThenBy(s => s.Date);
            if (MovieName != null)
            {
                query = query.Where(r => r.Title.Contains(MovieName));
            }           
            SelectedShowings = query.ToList();
            SelectedShowings.OrderBy(s => s.Date);
            ViewBag.TotalShowings= db.Showings.Count();
            ViewBag.SelectedShowings = SelectedShowings.Count();
            return View("Index", SelectedShowings);
           
        }

        // GET: Showings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Showing Showing = db.Showings.Find(id);
            if (Showing == null)
            {
                return HttpNotFound();
            }
            return View(Showing);
        }

        // GET: Showings/Create
        public ActionResult Create()
        {
            ViewBag.AllMovies = GetAllMovies();
            return View();
        }

        // POST: Showings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShowingID,Location,Title,Date,StartTime,EndTime, Pending,SpecialEvent MoviePrice")] Showing Showing, int SelectedMovies)
        {

            Movie movie = db.Movies.Find(SelectedMovies);
            Showing.Movie = movie;
            Showing.Title = movie.Title;
            //Showing.Movie.Title = movie.Title;
            Showing.Runtime = movie.Runtime;
            
            
            if (ModelState.IsValid)
            {
                db.Showings.Add(Showing);
                db.SaveChanges();

                int year = Showing.Date.Year;
                int month = Showing.Date.Month;
                int day = Showing.Date.Day;
                int hour = Showing.Date.Hour;
                int min = Showing.Date.Minute;
                int second = Showing.Date.Second;
                DateTime d2 = new DateTime(year, month, day + 1, hour, min, second);               
                Showing.Date = d2;
                db.Showings.Add(Showing);
                db.SaveChanges();

                DateTime d3 = new DateTime(year, month, day + 2, hour, min, second);
                Showing.Date = d3;
                db.Showings.Add(Showing);
                db.SaveChanges();

                DateTime d4 = new DateTime(year, month, day + 3, hour, min, second);
                Showing.Date = d4;
                db.Showings.Add(Showing);           
                db.SaveChanges();

                DateTime d5 = new DateTime(year, month, day + 4, hour, min, second);
                Showing.Date = d5;
                db.Showings.Add(Showing);
                db.SaveChanges();

                DateTime d6 = new DateTime(year, month, day + 5, hour, min, second);
                Showing.Date = d6;
                db.Showings.Add(Showing);
                db.SaveChanges();

                DateTime d7 = new DateTime(year, month, day + 6, hour, min, second);
                Showing.Date = d7;
                db.Showings.Add(Showing);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.AllMovies = GetAllMovies(Showing);
            return View(Showing);
        }


        public ActionResult ScheduleViewForManager(String MovieName)
        {

            
            var query = from s in db.Showings
                        select s;

            query = query.Where(s => s.Location.ToString() == "Theatre1");
            query = query.Where(s => s.Pending.ToString() == "No");
            query = query.OrderBy(s => s.Location).ThenBy(s => s.Date);

            List<Showing> ShowingsT1 = query.ToList();

         
            // no showing before 9am In T1           
            foreach (Showing showing in ShowingsT1)
               {
                int year = showing.Date.Year;
                int month = showing.Date.Month;
                int day = showing.Date.Day;
                DateTime NiNEAM = new DateTime(year, month, day, 09, 00, 00);
                if (showing.StartTime < NiNEAM)
                {
                    ViewBag.ErrorMessage1 = "You can't schedule showing before 9:00 AM";
                    return View("ShowingError");
                }
            }

            // one showing before 10am
            int count1 = 0;
            foreach (Showing showing in ShowingsT1)
            {
                int year = showing.Date.Year;
                int month = showing.Date.Month;
                int day = showing.Date.Day;
                DateTime TENAM = new DateTime(year, month, day, 10, 00, 00);
                if (showing.StartTime <= TENAM)
                {
                    count1 += 1;
                }
            }
            if (count1 == 0)
            {
                ViewBag.ErrorMessage1 = "There should be at least one movie start before 10 AM";
                return View("ShowingError");
            }

            // showing after 9:30pm
            int count2 = 0;
            foreach (Showing showing in ShowingsT1)
            {
                int year = showing.Date.Year;
                int month = showing.Date.Month;
                int day = showing.Date.Day;
                DateTime NineThirtyPM = new DateTime(year, month, day, 21, 30, 00);
                if (showing.EndTime > NineThirtyPM)
                {
                    count2 += 1;
                }
            }
            if (count2 == 0)
            {
                ViewBag.ErrorMessage1 = "You need to schedule an additional movie after 9:30 PM";
                return View("ShowingError");
            }

            foreach (Showing showing in ShowingsT1)
            {
                int year = showing.Date.Year;
                int month = showing.Date.Month;
                int day = showing.Date.Day;
                DateTime MIDNIGHT = new DateTime(year, month, day+1, 00, 00, 00);
                if (showing.EndTime > MIDNIGHT)
                {
                    ViewBag.ErrorMessage1 = "You can't schedule showing after Midnight";
                    return View("ShowingError");
                }
            }

            TimeSpan t2 = new TimeSpan(00, 00, 25, 00, 00);
            TimeSpan t3 = new TimeSpan(00, 00, 45, 00, 00);
            for (int i = 0; i <= ShowingsT1.Count() - 2; i++)
            {
                if (ShowingsT1[i + 1].Date.Day == ShowingsT1[i].Date.Day)
                {
                    if (ShowingsT1[i + 1].StartTime - ShowingsT1[i].EndTime < t2)
                    {

                        ViewBag.ErrorMessage1 = "The gap between two movies should be longer than 25 minutes";
                        return View("ShowingError");
                    }
                    if (ShowingsT1[i + 1].StartTime - ShowingsT1[i].EndTime > t3)
                    {

                        ViewBag.ErrorMessage1 = "The gap between two movies should be less than 45 minutes";
                        return View("ShowingError");
                    }
                }
            }

            var queryT2 = from s in db.Showings
                          select s;

            queryT2 = queryT2.Where(s => s.Location.ToString() == "Theatre2");
            queryT2 = queryT2.Where(s => s.Pending.ToString() == "No");
            queryT2 = queryT2.OrderBy(s => s.Date);

            List<Showing> ShowingsT2 = queryT2.ToList();

            // no showing before 9am
            foreach (Showing showing in ShowingsT2)
            {
                int year = showing.Date.Year;
                int month = showing.Date.Month;
                int day = showing.Date.Day;
                DateTime NiNEAM = new DateTime(year, month, day, 09, 00, 00);
                if (showing.StartTime < NiNEAM)
                {
                    ViewBag.ErrorMessage1 = "You can't schedule showing before 9:00 AM";
                    return View("ShowingError");
                }
            }

            // one showing before 10am
            int count3 = 0;
            foreach (Showing showing in ShowingsT2)
            {
                int year = showing.Date.Year;
                int month = showing.Date.Month;
                int day = showing.Date.Day;
                DateTime TENAM = new DateTime(year, month, day, 10, 00, 00);
                if (showing.StartTime <= TENAM)
                {
                    count3 += 1;
                }
            }
            if (count3 == 0)
            {
                ViewBag.ErrorMessage1 = "There should be at least one movie start before 10 AM";
                return View("ShowingError");
            }

            // showing after 9:30pm
            int count4 = 0;
            foreach (Showing showing in ShowingsT2)
            {
                int year = showing.Date.Year;
                int month = showing.Date.Month;
                int day = showing.Date.Day;
                DateTime NineThirtyPM = new DateTime(year, month, day, 21, 30, 00);
                if (showing.EndTime > NineThirtyPM)
                {
                    count4 += 1;
                }
            }
            if (count4 == 0)
            {

                ViewBag.ErrorMessage1 = "You need to schedule an additional movie after 9:30 PM";
                return View("ShowingError");
            }

            foreach (Showing showing in ShowingsT2)
            {
                int year = showing.Date.Year;
                int month = showing.Date.Month;
                int day = showing.Date.Day;
                DateTime MIDNIGHT = new DateTime(year, month, day+1, 00, 00, 00);
                if (showing.EndTime > MIDNIGHT)
                {
                    ViewBag.ErrorMessage1 = "You can't schedule showing after Midnight";
                    return View("ShowingError");
                }
            }
            for (int i = 0; i <= ShowingsT2.Count() - 2; i++)
            {
                if (ShowingsT2[i + 1].Date.Day == ShowingsT2[i].Date.Day)
                {
                        if (ShowingsT2[i + 1].StartTime - ShowingsT2[i].EndTime < t2)
                    {
                        ViewBag.ErrorMessage1 = "The gap between two movies should be longer than 25 minutes";
                        return View("ShowingError");
                    }
                    if (ShowingsT2[i + 1].StartTime - ShowingsT2[i].EndTime > t3)
                    {
                        ViewBag.ErrorMessage1 = "The gap between two movies should be less than 45 minutes";
                        return View("ShowingError");
                    }
                }
            }

            for (int i = 0; i <= ShowingsT1.Count() - 1; i++)
            {
                for (int j = 0; j <= ShowingsT2.Count() - 1; j++)
                {
                    if (ShowingsT1[i].Movie.Title == ShowingsT2[j].Movie.Title)
                    {
                        if (ShowingsT1[i].StartTime == ShowingsT2[j].StartTime)
                        {
                            ViewBag.ErrorMessage1 = "The movie can't have same showtime on two theatres";
                            return View("ShowingError");
                        }
                    }
                }
            }


           

            
           
           
            var queryFinal = from s in db.Showings
                             select s;

            if (MovieName != null)
            {
                query = query.Where(r => r.Title.Contains(MovieName));
            }
            queryFinal = queryFinal.Where(s => s.Pending.ToString() == "No");            
            queryFinal = queryFinal.OrderBy(s => s.Location.ToString()).ThenBy(s => s.Date);
            ViewBag.TotalShowings = db.Showings.Count();
            ViewBag.SelectedShowings = queryFinal.Count();
            List<Showing> FinalShowings = queryFinal.ToList();
            return View("ScheduleViewForManager", queryFinal);

        }

        public ActionResult ScheduleViewForCustomer(String MovieName)
        {
            var query = from s in db.Showings
                        select s;

            query = query.Where(s => s.Location.ToString() == "Theatre1");
            query = query.Where(s => s.Pending.ToString() == "No");
            query = query.OrderBy(s => s.Location).ThenBy(s => s.Date);

            List<Showing> ShowingsT1 = query.ToList();

            // no showing before 9am In T1           
            foreach (Showing showing in ShowingsT1)
            {
                int year = showing.Date.Year;
                int month = showing.Date.Month;
                int day = showing.Date.Day;
                DateTime NiNEAM = new DateTime(year, month, day, 09, 00, 00);
                if (showing.StartTime < NiNEAM)
                {
                    ViewBag.ErrorMessage1 = "No schedule available";
                    return View("ShowingError");
                }
            }

            // one showing before 10am
            int count1 = 0;      
            foreach (Showing showing in ShowingsT1)
            {
                int year = showing.Date.Year;
                int month = showing.Date.Month;
                int day = showing.Date.Day;
                DateTime TENAM = new DateTime(year, month, day, 10, 00, 00);
                if (showing.StartTime <= TENAM)
                {
                    count1 += 1;
                }
            }
            if (count1 == 0)
            {
                ViewBag.ErrorMessage1 = "No schedule available";
                return View("ShowingError");
            }

            // showing after 9:30pm
            int count2 = 0;
            foreach (Showing showing in ShowingsT1)
            {
                int year = showing.Date.Year;
                int month = showing.Date.Month;
                int day = showing.Date.Day;
                DateTime NineThirtyPM = new DateTime(year, month, day, 21, 30, 00);
                if (showing.EndTime > NineThirtyPM)
                {
                    count2 += 1;
                }
            }
            if (count2 == 0)
            {
                ViewBag.ErrorMessage1 = "No schedule available";
                return View("ShowingError");
            }

            foreach (Showing showing in ShowingsT1)
            {
                int year = showing.Date.Year;
                int month = showing.Date.Month;
                int day = showing.Date.Day;
                DateTime MIDNIGHT = new DateTime(year, month, day+1, 00, 00, 00);
                if (showing.EndTime > MIDNIGHT)
                {
                    ViewBag.ErrorMessage1 = "No schedule available";
                    return View("ShowingError");
                }
            }

            TimeSpan t2 = new TimeSpan(00, 00, 25, 00, 00);
            TimeSpan t3 = new TimeSpan(00, 00, 45, 00, 00);
            for (int i = 0; i <= ShowingsT1.Count() - 2; i++)
            {
                if (ShowingsT1[i + 1].Date.Day == ShowingsT1[i].Date.Day)
                {
                    if (ShowingsT1[i + 1].StartTime - ShowingsT1[i].EndTime < t2)
                    {

                        ViewBag.ErrorMessage1 = "No schedule available";
                        return View("ShowingError");
                    }
                    if (ShowingsT1[i + 1].StartTime - ShowingsT1[i].EndTime > t3)
                    {

                        ViewBag.ErrorMessage1 = "No schedule available";
                        return View("ShowingError");
                    }
                }
            }

            var queryT2 = from s in db.Showings
                          select s;

            queryT2 = queryT2.Where(s => s.Location.ToString() == "Theatre2");
            queryT2 = queryT2.Where(s => s.Pending.ToString() == "No");
            queryT2 = queryT2.OrderBy(s => s.Date);
        
            List<Showing> ShowingsT2 = queryT2.ToList();

            // no showing before 9am
            foreach (Showing showing in ShowingsT2)
            {
                int year = showing.Date.Year;
                int month = showing.Date.Month;
                int day = showing.Date.Day;
                DateTime NiNEAM = new DateTime(year, month, day, 09, 00, 00);
                if (showing.StartTime < NiNEAM)
                {
                    ViewBag.ErrorMessage1 = "No schedule available";
                    return View("ShowingError");
                }
            }

            // one showing before 10am
            int count3 = 0;
            foreach (Showing showing in ShowingsT2)
            {
                int year = showing.Date.Year;
                int month = showing.Date.Month;
                int day = showing.Date.Day;
                DateTime TENAM = new DateTime(year, month, day, 10, 00, 00);
                if (showing.StartTime <= TENAM)
                {
                    count3 += 1;
                }
            }
            if (count3 == 0)
            {
                ViewBag.ErrorMessage1 = "No schedule available";
                return View("ShowingError");
            }

            // showing after 9:30pm
            int count4 = 0;
            foreach (Showing showing in ShowingsT2)
            {
                int year = showing.Date.Year;
                int month = showing.Date.Month;
                int day = showing.Date.Day;
                DateTime NineThirtyPM = new DateTime(year, month, day, 21, 30, 00);
                if (showing.EndTime > NineThirtyPM)
                {
                    count4 += 1;
                }
            }
            if (count4 == 0)
            {

                ViewBag.ErrorMessage1 = "No schedule available";
                return View("ShowingError");
            }

            //foreach (Showing showing in ShowingsT2)
            //{
            //    int year = showing.Date.Year;
            //    int month = showing.Date.Month;
            //    int day = showing.Date.Day;
            //    DateTime MIDNIGHT = new DateTime(year, month, day+1, 00, 00, 00);
            //    if (showing.EndTime > MIDNIGHT)
            //    {
            //        ViewBag.ErrorMessage1 = "No schedule available";
            //        return View("ShowingError");
            //    }
            //}

            for (int i = 0; i <= ShowingsT2.Count() - 2; i++)
            {
                if (ShowingsT2[i + 1].Date.Day == ShowingsT2[i].Date.Day)
                {
                    if (ShowingsT2[i + 1].StartTime - ShowingsT2[i].EndTime < t2)
                    {
                        ViewBag.ErrorMessage1 = "No schedule available";
                        return View("ShowingError");
                    }
                    if (ShowingsT2[i + 1].StartTime - ShowingsT2[i].EndTime > t3)
                    {
                        ViewBag.ErrorMessage1 = "No schedule available";
                        return View("ShowingError");
                    }
                }
            }

            for (int i = 0; i <= ShowingsT1.Count() - 1; i++)
            {
                for (int j = 0; j <= ShowingsT2.Count() - 1; j++)
                {
                    if (ShowingsT1[i].Movie.Title == ShowingsT2[j].Movie.Title)
                    {
                        if (ShowingsT1[i].StartTime == ShowingsT2[j].StartTime)
                        {
                            ViewBag.ErrorMessage1 = "No schedule available";
                            return View("ShowingError");
                        }
                    }
                }
            }


            var queryFinal = from s in db.Showings
                             select s;
            if (MovieName != null)
            {
                query = query.Where(r => r.Title.Contains(MovieName));
            }
            queryFinal = queryFinal.Where(s => s.Pending.ToString() == "No");
            queryFinal = queryFinal.OrderBy(s => s.Location.ToString()).ThenBy(s => s.Date);
            ViewBag.TotalShowings = db.Showings.Count();
            ViewBag.SelectedShowings = queryFinal.Count();
            List<Showing> FinalShowings = queryFinal.ToList();
            return View("ScheduleViewForCustomer", queryFinal);


        }


            // GET: Showings/Edit/5
            public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Showing Showing = db.Showings.Find(id);
            if (Showing == null)
            {
                return HttpNotFound();
            }
            ViewBag.AllMovies = GetAllMovies(Showing);
            return View(Showing);
        }

        // POST: Showings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShowingID,Location,Title,Date, StartTime,EndTime, Pending, SpecialEvent")] Showing Showing, int SelectedMovies)
        {

            if (ModelState.IsValid)
            {
                Showing ShowingToChange = db.Showings.Find(Showing.ShowingID);
              
                Movie movie = db.Movies.Find(SelectedMovies);
                ShowingToChange.Movie = movie;
                ShowingToChange.Title = movie.Title;
                ShowingToChange.Movie.Title = movie.Title;
                ShowingToChange.Location = Showing.Location;
                ShowingToChange.Date = Showing.Date;
                ShowingToChange.Runtime = movie.Runtime;            
                ShowingToChange.Pending = Showing.Pending;
                ShowingToChange.SpecialEvent = Showing.SpecialEvent;
                db.Entry(ShowingToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AllMovies = GetAllMovies(Showing);
            return View(Showing);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Showing showing = db.Showings.Find(id);
            if (showing == null)
            {
                return HttpNotFound();
            }
            return View(showing);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Showing showing = db.Showings.Find(id);
            db.Showings.Remove(showing);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public SelectList GetAllMovies()
        {
            List<Movie> allmovies = db.Movies.OrderBy(d => d.Title).ToList();

            SelectList selmovies = new SelectList(allmovies, "MovieID", "Title");

            return selmovies;
        }

        public SelectList GetAllMovies(Showing Showing)
        {
            List<Movie> allmovies = db.Movies.OrderBy(d => d.Title).ToList();


           // List<Int32> SelectedMovies = new List<Int32>();           
            Int32 SelectedMovies = Showing.Movie.MovieID;        
            SelectList selmovies = new SelectList(allmovies, "MovieID", "Title", SelectedMovies);


            return selmovies;
        }
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
