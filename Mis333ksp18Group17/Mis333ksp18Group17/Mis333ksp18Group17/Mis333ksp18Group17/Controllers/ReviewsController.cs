using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using Microsoft.AspNet.Identity;
using System.Web;
using System.Web.Mvc;
using Mis333ksp18Group17.DAL;
using Mis333ksp18Group17.Models;

namespace Mis333ksp18Group17.Controllers
{
    public enum enumCustomerRating { a, b, c, d, e }
    public class ReviewsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Reviews
        public ActionResult Index()
        {
            return View(db.Reviews.ToList());
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            ViewBag.AllMovies = GetAllMovies();
           
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReviewID,Reviews,CustomerRating,Vote")] Review review, int SelectedMovies, enumCustomerRating Rating)
        {
            Movie movie = db.Movies.Find(SelectedMovies);
            review.Movie = movie;
            if (Rating == enumCustomerRating.a){
                review.CustomerRating = 1;
            }
            else if (Rating == enumCustomerRating.b)
            {
                review.CustomerRating = 3;
            }
            else if (Rating == enumCustomerRating.c){
                review.CustomerRating = 3;
            }
            else if(Rating == enumCustomerRating.d){
                review.CustomerRating = 4;
            }
            else {
                review.CustomerRating = 5;
            }
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AllMovies = GetAllMovies(review);
            return View(review);
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReviewID,Reviews,CustomerRating,Vote")] Review review, int SelectedMovies, enumCustomerRating Rating)
        {
            
            if (ModelState.IsValid)
            {
                Review ReviewToChange = db.Reviews.Find(review.ReviewID);

                //Movie movie = db.Movies.Find(SelectedMovies);
                ReviewToChange.Movie = review.Movie;
                if (Rating == enumCustomerRating.a)
                {
                    ReviewToChange.CustomerRating = 1;
                }
                else if (Rating == enumCustomerRating.b)
                {
                    ReviewToChange.CustomerRating = 3;
                }
                else if (Rating == enumCustomerRating.c)
                {
                    ReviewToChange.CustomerRating = 3;
                }
                else if (Rating == enumCustomerRating.d)
                {
                    ReviewToChange.CustomerRating = 4;
                }
                else
                {
                    ReviewToChange.CustomerRating = 5;
                }
                ReviewToChange.Reviews = review.Reviews;
                ReviewToChange.Vote = review.Vote;
                db.Entry(ReviewToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }       
            return View(review);
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public SelectList GetAllMovies()
        {
            String UserID = User.Identity.GetUserId();
            List<Order> orders = db.Orders.Where(c => c.AppUser.Id == UserID).Where(c=>c.CheckOutStatus == true).ToList();
           
            List<Movie> movies = new List<Movie>();
            foreach (Order order in orders)
            {
               List<OrderDetail> ods = order.OrderDetails;
                foreach (OrderDetail od in ods)
                {                   
                    movies.Add(od.Showing.Movie);
                }
            }
            movies.Select(m => m.Title).Distinct();
            SelectList selmovies = new SelectList(movies, "MovieID", "Title");
            return selmovies;
        }

        public SelectList GetAllMovies(Review review)
        {
            String UserID = User.Identity.GetUserId();
            List<Order> orders = db.Orders.Where(c => c.AppUser.Id == UserID).Where(c => c.CheckOutStatus == true).ToList();
            List<Movie> movies = new List<Movie>();
            foreach (Order order in orders)
            {
                List<OrderDetail> ods = order.OrderDetails;
                foreach (OrderDetail od in ods)
                {
                    
                    movies.Add(od.Showing.Movie);
                }
            }
            Int32 SelectedMovies = review.Movie.MovieID;
            movies.Select(m =>m.Title).Distinct();
            SelectList selmovies = new SelectList(movies, "MovieID", "Title", SelectedMovies);

            return selmovies;
        }

        //public SelectList GetAllMovies(Showing Showing)
        //{
        //    List<Movie> allmovies = db.Movies.OrderBy(d => d.Title).ToList();


        //    // List<Int32> SelectedMovies = new List<Int32>();           
        //    Int32 SelectedMovies = Showing.Movie.MovieID;
        //    SelectList selmovies = new SelectList(allmovies, "MovieID", "Title", SelectedMovies);


        //    return selmovies;
        //}


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
