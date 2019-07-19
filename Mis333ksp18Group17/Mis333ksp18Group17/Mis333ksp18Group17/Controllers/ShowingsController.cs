using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;

using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Mis333ksp18Group17.DAL;
using Mis333ksp18Group17.Models;
using System.Net.Mail;


namespace Mis333ksp18Group17.Controllers
{
    public class ShowingsController : Controller
    {
        public enum Pending { Yes, No }
        private AppDbContext db = new AppDbContext();

        // GET: Showings
        [Authorize(Roles ="Manager")]
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
        [AllowAnonymous]
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
        [Authorize(Roles = "Manager")]
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
        public ActionResult Create([Bind(Include = "ShowingID,Location,Title,Date,StartTime,EndTime, Pending,SpecialEvent,MoviePrice, Publish")] Showing Showing, int SelectedMovies)
        {

            Movie movie = db.Movies.Find(SelectedMovies);
            Showing.Movie = movie;
            Showing.Title = movie.Title;
            //Showing.Movie.Title = movie.Title;
            Showing.Runtime = movie.Runtime;
            
            Showing.Publish = false;

            if (ModelState.IsValid)
            {
                Showing.MoviePrice = GetPrice(Showing);
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
                Showing.MoviePrice = GetPrice(Showing);
                db.Showings.Add(Showing);
                db.SaveChanges();

                DateTime d3 = new DateTime(year, month, day + 2, hour, min, second);
                Showing.Date = d3;
                Showing.MoviePrice = GetPrice(Showing);
                db.Showings.Add(Showing);
                db.SaveChanges();

                DateTime d4 = new DateTime(year, month, day + 3, hour, min, second);
                Showing.Date = d4;
                Showing.MoviePrice = GetPrice(Showing);
                db.Showings.Add(Showing);           
                db.SaveChanges();

                DateTime d5 = new DateTime(year, month, day + 4, hour, min, second);
                Showing.Date = d5;
                Showing.MoviePrice = GetPrice(Showing);
                db.Showings.Add(Showing);
                db.SaveChanges();

                DateTime d6 = new DateTime(year, month, day + 5, hour, min, second);
                Showing.Date = d6;
                Showing.MoviePrice = GetPrice(Showing);
                db.Showings.Add(Showing);
                db.SaveChanges();

                DateTime d7 = new DateTime(year, month, day + 6, hour, min, second);
                Showing.Date = d7;
                Showing.MoviePrice = GetPrice(Showing);
                db.Showings.Add(Showing);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.AllMovies = GetAllMovies(Showing);
            return View(Showing);
        }

        [Authorize(Roles = "Manager")]
        public ActionResult ScheduleViewForManager([Bind(Include = "ShowingID,Publish")]String MovieName)
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
            foreach (Showing s in FinalShowings)
            {
                Showing showToChange = db.Showings.Find(s.ShowingID);
                showToChange.Publish = true;
                db.Entry(showToChange).State = EntityState.Modified;
                db.SaveChanges();

            }
            return View("ScheduleViewForManager", FinalShowings);
            
        }

        [AllowAnonymous]
        public ActionResult ScheduleViewForCustomer(String MovieName, DateTime? SelectedShowTime, Classification? SelectedClass1)
        {

            var query = from s in db.Showings
                        select s;
            query = query.Where(s => s.Publish);
            query = query.Where(s => s.ShowingCancelStatus.ToString() == "No");
            ViewBag.TotalShowings = query.Count();
            if (MovieName != null)
            {
                query = query.Where(r => r.Title.Contains(MovieName));
            }

            if (SelectedShowTime != null)
            {

                switch (SelectedClass1)
                {
                    case Classification.After:

                        query = query.Where(r => r.Date >= SelectedShowTime);

                        break;
                    case Classification.Before:

                        query = query.Where(r => r.Date < SelectedShowTime);

                        break;
                    case Classification.All:        
                        break;
                        //case Classification.Equal:

                        //    query = query.Where(r => r.StartTime == SelectedShowTime);

                        //    break;

                }
            }


            ViewBag.SelectedShowings = query.Count();
            return View("ScheduleViewForCustomer", query);
            //    var query = from s in db.Showings
            //                select s;

            //    query = query.Where(s => s.Location.ToString() == "Theatre1");
            //    query = query.Where(s => s.Pending.ToString() == "No");
            //    query = query.OrderBy(s => s.Location).ThenBy(s => s.Date);

            //    List<Showing> ShowingsT1 = query.ToList();

            //    // no showing before 9am In T1           
            //    foreach (Showing showing in ShowingsT1)
            //    {
            //        int year = showing.Date.Year;
            //        int month = showing.Date.Month;
            //        int day = showing.Date.Day;
            //        DateTime NiNEAM = new DateTime(year, month, day, 09, 00, 00);
            //        if (showing.StartTime < NiNEAM)
            //        {
            //            ViewBag.ErrorMessage1 = "No schedule available";
            //            return View("ShowingError");
            //        }
            //    }

            //    // one showing before 10am
            //    int count1 = 0;      
            //    foreach (Showing showing in ShowingsT1)
            //    {
            //        int year = showing.Date.Year;
            //        int month = showing.Date.Month;
            //        int day = showing.Date.Day;
            //        DateTime TENAM = new DateTime(year, month, day, 10, 00, 00);
            //        if (showing.StartTime <= TENAM)
            //        {
            //            count1 += 1;
            //        }
            //    }
            //    if (count1 == 0)
            //    {
            //        ViewBag.ErrorMessage1 = "No schedule available";
            //        return View("ShowingError");
            //    }

            //    // showing after 9:30pm
            //    int count2 = 0;
            //    foreach (Showing showing in ShowingsT1)
            //    {
            //        int year = showing.Date.Year;
            //        int month = showing.Date.Month;
            //        int day = showing.Date.Day;
            //        DateTime NineThirtyPM = new DateTime(year, month, day, 21, 30, 00);
            //        if (showing.EndTime > NineThirtyPM)
            //        {
            //            count2 += 1;
            //        }
            //    }
            //    if (count2 == 0)
            //    {
            //        ViewBag.ErrorMessage1 = "No schedule available";
            //        return View("ShowingError");
            //    }

            //    foreach (Showing showing in ShowingsT1)
            //    {
            //        int year = showing.Date.Year;
            //        int month = showing.Date.Month;
            //        int day = showing.Date.Day;
            //        DateTime MIDNIGHT = new DateTime(year, month, day+1, 00, 00, 00);
            //        if (showing.EndTime > MIDNIGHT)
            //        {
            //            ViewBag.ErrorMessage1 = "No schedule available";
            //            return View("ShowingError");
            //        }
            //    }

            //    TimeSpan t2 = new TimeSpan(00, 00, 25, 00, 00);
            //    TimeSpan t3 = new TimeSpan(00, 00, 45, 00, 00);
            //    for (int i = 0; i <= ShowingsT1.Count() - 2; i++)
            //    {
            //        if (ShowingsT1[i + 1].Date.Day == ShowingsT1[i].Date.Day)
            //        {
            //            if (ShowingsT1[i + 1].StartTime - ShowingsT1[i].EndTime < t2)
            //            {

            //                ViewBag.ErrorMessage1 = "No schedule available";
            //                return View("ShowingError");
            //            }
            //            if (ShowingsT1[i + 1].StartTime - ShowingsT1[i].EndTime > t3)
            //            {

            //                ViewBag.ErrorMessage1 = "No schedule available";
            //                return View("ShowingError");
            //            }
            //        }
            //    }

            //    var queryT2 = from s in db.Showings
            //                  select s;

            //    queryT2 = queryT2.Where(s => s.Location.ToString() == "Theatre2");
            //    queryT2 = queryT2.Where(s => s.Pending.ToString() == "No");
            //    queryT2 = queryT2.OrderBy(s => s.Date);

            //    List<Showing> ShowingsT2 = queryT2.ToList();

            //    // no showing before 9am
            //    foreach (Showing showing in ShowingsT2)
            //    {
            //        int year = showing.Date.Year;
            //        int month = showing.Date.Month;
            //        int day = showing.Date.Day;
            //        DateTime NiNEAM = new DateTime(year, month, day, 09, 00, 00);
            //        if (showing.StartTime < NiNEAM)
            //        {
            //            ViewBag.ErrorMessage1 = "No schedule available";
            //            return View("ShowingError");
            //        }
            //    }

            //    // one showing before 10am
            //    int count3 = 0;
            //    foreach (Showing showing in ShowingsT2)
            //    {
            //        int year = showing.Date.Year;
            //        int month = showing.Date.Month;
            //        int day = showing.Date.Day;
            //        DateTime TENAM = new DateTime(year, month, day, 10, 00, 00);
            //        if (showing.StartTime <= TENAM)
            //        {
            //            count3 += 1;
            //        }
            //    }
            //    if (count3 == 0)
            //    {
            //        ViewBag.ErrorMessage1 = "No schedule available";
            //        return View("ShowingError");
            //    }

            //    // showing after 9:30pm
            //    int count4 = 0;
            //    foreach (Showing showing in ShowingsT2)
            //    {
            //        int year = showing.Date.Year;
            //        int month = showing.Date.Month;
            //        int day = showing.Date.Day;
            //        DateTime NineThirtyPM = new DateTime(year, month, day, 21, 30, 00);
            //        if (showing.EndTime > NineThirtyPM)
            //        {
            //            count4 += 1;
            //        }
            //    }
            //    if (count4 == 0)
            //    {

            //        ViewBag.ErrorMessage1 = "No schedule available";
            //        return View("ShowingError");
            //    }

            //    foreach (Showing showing in ShowingsT2)
            //    {
            //        int year = showing.Date.Year;
            //        int month = showing.Date.Month;
            //        int day = showing.Date.Day;
            //        DateTime MIDNIGHT = new DateTime(year, month, day + 1, 00, 00, 00);
            //        if (showing.EndTime > MIDNIGHT)
            //        {
            //            ViewBag.ErrorMessage1 = "No schedule available";
            //            return View("ShowingError");
            //        }
            //    }

            //    for (int i = 0; i <= ShowingsT2.Count() - 2; i++)
            //    {
            //        if (ShowingsT2[i + 1].Date.Day == ShowingsT2[i].Date.Day)
            //        {
            //            if (ShowingsT2[i + 1].StartTime - ShowingsT2[i].EndTime < t2)
            //            {
            //                ViewBag.ErrorMessage1 = "No schedule available";
            //                return View("ShowingError");
            //            }
            //            if (ShowingsT2[i + 1].StartTime - ShowingsT2[i].EndTime > t3)
            //            {
            //                ViewBag.ErrorMessage1 = "No schedule available";
            //                return View("ShowingError");
            //            }
            //        }
            //    }

            //    for (int i = 0; i <= ShowingsT1.Count() - 1; i++)
            //    {
            //        for (int j = 0; j <= ShowingsT2.Count() - 1; j++)
            //        {
            //            if (ShowingsT1[i].Movie.Title == ShowingsT2[j].Movie.Title)
            //            {
            //                if (ShowingsT1[i].StartTime == ShowingsT2[j].StartTime)
            //                {
            //                    ViewBag.ErrorMessage1 = "No schedule available";
            //                    return View("ShowingError");
            //                }
            //            }
            //        }
            //    }


            //    var queryFinal = from s in db.Showings
            //                     select s;
            //    if (MovieName != null)
            //    {
            //        query = query.Where(r => r.Title.Contains(MovieName));
            //    }
            //    queryFinal = queryFinal.Where(s => s.Pending.ToString() == "No");
            //    queryFinal = queryFinal.OrderBy(s => s.Location.ToString()).ThenBy(s => s.Date);
            //    ViewBag.TotalShowings = db.Showings.Count();
            //    ViewBag.SelectedShowings = queryFinal.Count();
            //    List<Showing> FinalShowings = queryFinal.ToList();
            //    return View("ScheduleViewForCustomer", FinalShowings);


            //}

        }
            // GET: Showings/Edit/5
            [Authorize(Roles = "Manager")]
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
        [Authorize(Roles = "Manager")]
        public ActionResult Edit([Bind(Include = "ShowingID,Location,Title,Date, StartTime,EndTime, Pending, SpecialEvent,MoviePrice,Publish")] Showing Showing, int SelectedMovies)
        {
            Showing ShowingToChange = db.Showings.Find(Showing.ShowingID);
            if(ShowingToChange.Date == null)
            {
                ViewBag.NoDate = "You need to select a date";
                return View("ShowingError");
            }

            if (ModelState.IsValid)
            {
              
              
                Movie movie = db.Movies.Find(SelectedMovies);
                ShowingToChange.Movie = movie;
                ShowingToChange.Title = movie.Title;
                ShowingToChange.Movie.Title = movie.Title;
                ShowingToChange.Location = Showing.Location;
                ShowingToChange.Date = Showing.Date;
                ShowingToChange.Runtime = movie.Runtime;            
                ShowingToChange.Pending = Showing.Pending;
                ShowingToChange.SpecialEvent = Showing.SpecialEvent;
                ShowingToChange.MoviePrice = GetPrice(Showing);
                ShowingToChange.Publish = false;
                db.Entry(ShowingToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AllMovies = GetAllMovies(Showing);
            return View(Showing);
        }

        //[Authorize(Roles = "Manager")]
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Showing showing = db.Showings.Find(id);
        //    if (showing == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(showing);
        //}

        //// POST: Orders/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Showing showing = db.Showings.Find(id);
        //    db.Showings.Remove(showing);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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

        Int32 intPrice;
        public Int32 GetPrice(Showing Showing)
        {
            if (Showing.Date.DayOfWeek.ToString() == "Saturday" || Showing.Date.DayOfWeek.ToString() == "Sunday")
            {
                intPrice = 12;
            }
            if (Showing.SpecialEvent == SpecialEvent.Yes)
            {
                if (Showing.Date.DayOfWeek.ToString() == "Friday")
                {
                    if (Showing.StartTime.Hour >= 12)
                    {
                        intPrice = 12;
                    }
                    else
                    {
                        intPrice = 10;
                    }
                }
                else
                {
                    intPrice = 10;
                }

            }
            else
            {

                if (Showing.Date.DayOfWeek.ToString() == "Friday")
                {
                    if (Showing.StartTime.Hour >= 12)
                    {
                        intPrice = 12;
                    }
                    else
                    {
                        intPrice = 5;
                    }
                }
                if (Showing.Date.DayOfWeek.ToString() == "Monday" || Showing.Date.DayOfWeek.ToString() == "Wednesday" || Showing.Date.DayOfWeek.ToString() == "Thursday")
                {
                    if (Showing.StartTime.Hour < 12)
                    {
                        intPrice = 5;
                    }
                    else
                    {
                        intPrice = 10;
                    }
                }
                if (Showing.Date.DayOfWeek.ToString() == "Tuesday")
                {
                    if (Showing.StartTime.Hour < 17)
                    {
                        intPrice = 8;
                    }
                    else
                    {
                        intPrice = 10;
                    }
                }

            }
            return intPrice;
        }

        [Authorize(Roles ="Manager")]
        public ActionResult Cancellation(int? id)
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
            if (Showing.ShowingCancelStatus == ShowingCancelStatus.Yes)
            {
                ViewBag.NoCancelTwice = "This showing has already been cancelled";
                return View("ShowingError");
            }
            if (DateTime.Today > Showing.StartTime)
            {
                ViewBag.ErrorCancellationShowing = "You can't cancel this showing because it has already started";
                return View("ShowingError");
            }

            return View(Showing);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cancellation([Bind(Include = "ShowingID, CancelStatus")] Showing Showing, Confirm Confirm)
        {
           

            Showing showingToChange = db.Showings.Find(Showing.ShowingID);

            List<OrderDetail> ods = showingToChange.OrderDetails;
            if (Confirm == Confirm.Yes)
            {

                showingToChange.ShowingCancelStatus = ShowingCancelStatus.Yes;
                db.Entry(showingToChange).State = EntityState.Modified;
                db.SaveChanges();
                foreach (OrderDetail od in ods)
                {
                    if (od.Order.PaymentMethod == PaymentMethod.PopcornPoints.ToString())
                    {
                        AppUser AppUser = db.Users.Find(od.Order.AppUser.Id);
                        Int32 popcornBalance = AppUser.PopcornPoints;
                        AppUser.PopcornPoints = AppUser.PopcornPoints + 100;
                        String emailSubject = "Cancellation";
                        String emailBody = "Your ticket " + showingToChange.MovieAndDate + " is cancelled.";
                        SendEmail(AppUser.Email, emailSubject, emailBody);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        AppUser AppUser = db.Users.Find(od.Order.AppUser.Id);
                        //Int32 popcornBalance = AppUser.PopcornPoints;
                        //AppUser.PopcornPoints = AppUser.PopcornPoints + 100;
                        String emailSubject = "Cancellation";
                        String emailBody = "Your ticket " + showingToChange.MovieAndDate + " is cancelled.";
                        SendEmail(AppUser.Email, emailSubject, emailBody);
                        return RedirectToAction("Index");
                    }

                }   
                   
                
            }
                showingToChange.ShowingCancelStatus = ShowingCancelStatus.No;
                db.Entry(showingToChange).State = EntityState.Modified;
                db.SaveChanges();         
                return RedirectToAction("Index");
            
            
        }

        public static void SendEmail(String toEmailAddress, String emailSubject, String emailBody)
        {

            //Create an email client to send the emails
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("sandyyingrui0921@gmail.com", "YRyr@96092"),
                EnableSsl = true
            };
            //Add anything that you need to the body of the message
            // /n is a new line – this will add some white space after the main body of the message
            String finalMessage = emailBody + "\n\n Thank You!" + "\n Team 17";
            //Create an email address object for the sender address
            MailAddress senderEmail = new MailAddress("sandyyingrui0921@gmail.com", "Team 17");

            MailMessage mm = new MailMessage();
            mm.Subject = "Team 17 - " + emailSubject;
            mm.Sender = senderEmail;
            mm.From = senderEmail;
            mm.To.Add(new MailAddress(toEmailAddress));
            mm.Body = finalMessage;
            client.Send(mm);
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
