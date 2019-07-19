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
    public class MoviesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Movies
        public ActionResult Index()
        {
            return View(db.Movies.ToList());
        }

        // GET: Movies/Details/5
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

        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.AllGenres = GetAllGenres();
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieID,MovieNum,Title,Tagline,Genre,ReleaseDate,MPAARating,Actors,Runtime,Overview,Revenue")] Movie movie, int[] SelectedGenres)
        {

            movie.MovieNum = Utilities.GenerateMovieNumber.GetNextMovieNumber();
            if (SelectedGenres == null)
            {
                ViewBag.ErrorM = "You must select at least a genre.";
                return View("error");
            }
            foreach (int i in SelectedGenres)
            {
                Genre gr = db.Genres.Find(i);
                movie.Genres.Add(gr);
            }


            DateTime lowDate = new DateTime(1927, 01, 01);
            if (movie.ReleaseDate > lowDate)
            {
                if (ModelState.IsValid)
                {
                    db.Movies.Add(movie);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            
            ViewBag.AllGenres = GetAllGenres(movie);

            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.AllGenres = GetAllGenres(movie);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieID,MovieNum,Title,Tagline,Genre,ReleaseDate,MPAARating,Actors,Runtime,Overview,Revenue")] Movie movie, int[]SelectedGenres)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public MultiSelectList GetAllGenres()
        {
            List<Genre> allGenres = db.Genres.OrderBy(d => d.Name).ToList();

            MultiSelectList selGenres = new MultiSelectList(allGenres, "GenreID","Name");

            return selGenres;
        }

        public MultiSelectList GetAllGenres(Movie movie)
        {
            List<Genre> allGenres = db.Genres.OrderBy(v => v.Name).ToList();

            List<Int32> SelectedGenres = new List<Int32>();

            foreach (Genre gr in movie.Genres)
            {
                SelectedGenres.Add(gr.GenreID);
            }

            //create the multiselect list
            MultiSelectList selGenres = new MultiSelectList(allGenres, "GenreID", "Name", SelectedGenres);

            //return the multiselect list
            return selGenres;

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
