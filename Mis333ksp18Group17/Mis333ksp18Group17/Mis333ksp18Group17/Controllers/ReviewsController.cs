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
        [Authorize(Roles = "Employee")]
        public ActionResult Index()
        {
            return View(db.Reviews.OrderBy(r => r.DownVote + r.UpVote).ToList());
        }
        [AllowAnonymous]
        public ActionResult Approved()
        {
            return View(db.Reviews.Where(r => r.Approve == Approve.Yes).OrderByDescending(r=>r.DownVote + r.UpVote).ToList());
        }

        [AllowAnonymous]
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
        [Authorize(Roles = "Customer")]
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
        public ActionResult Create([Bind(Include = "ReviewID,Reviews,CustomerRating,Vote, Approve, UpVote, DownVote")] Review review, int SelectedMovies, enumCustomerRating Rating)
        {
            Movie movie = db.Movies.Find(SelectedMovies);
            review.Movie = movie;
            review.appuser = db.Users.Find(User.Identity.GetUserId());
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
            review.Approve = Approve.No;
            review.UpVote = 0;
            review.DownVote = 0;
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Approved");
            }
            ViewBag.AllMovies = GetAllMovies(review);
            return View(review);
        }

        // GET: Reviews/Edit/5
        [Authorize]
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
            if (User.IsInRole("Employee") || review.appuser.Id == User.Identity.GetUserId())
            {
                return View(review);
            }

            else
            {
                return View("Error", new string[] { "This is not your profile" });
            }
          
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReviewID,Reviews,CustomerRating,Vote,Approve")] Review review, enumCustomerRating Rating)
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
                ReviewToChange.Approve = review.Approve;
                ReviewToChange.Reviews = review.Reviews;
                db.Entry(ReviewToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }       
            return View(review);
        }

        // GET: Reviews/Upvote
        [Authorize(Roles = "Customer")]
        public ActionResult Upvote(int? id)
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

        // POST: Reviews/Upvote
        [HttpPost, ActionName("Upvote")]
        [ValidateAntiForgeryToken]
        public ActionResult Upvote([Bind(Include = "ReviewID, UpVote")]Review review, Confirm Confirm)
        {
            Review ReviewToChange = db.Reviews.Find(review.ReviewID);
            if(Confirm.ToString() == "Yes")
            {
                 ReviewToChange.UpVote = ReviewToChange.UpVote + 1;
                 db.Entry(ReviewToChange).State = EntityState.Modified;
                 db.SaveChanges();
                 return RedirectToAction("Approved");
            }
                      
           
          //  ViewBag.Upvote = "You have successfully upvote this review";
            return RedirectToAction("Approved");
        }

        // GET: Reviews/Downvote
        [Authorize(Roles = "Customer")]
        public ActionResult Downvote(int? id)
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

        // POST: Reviews/Downvote
        [HttpPost, ActionName("Downvote")]
        [ValidateAntiForgeryToken]
        public ActionResult Downvote([Bind(Include = "ReviewID, DownVote")]Review review, Confirm Confirm)
        {
            Review ReviewToChange = db.Reviews.Find(review.ReviewID);
            if (Confirm.ToString() == "Yes")
            {
                ReviewToChange.DownVote = ReviewToChange.DownVote + 1;
                db.Entry(ReviewToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Approved");
            }
            return RedirectToAction("Approved");
                }

        //// GET: Reviews/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Review review = db.Reviews.Find(id);
        //    if (review == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(review);
        //}

        //// POST: Reviews/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Review review = db.Reviews.Find(id);
        //    db.Reviews.Remove(review);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
