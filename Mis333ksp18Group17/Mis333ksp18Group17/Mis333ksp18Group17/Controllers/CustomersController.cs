using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Mis333ksp18Group17.DAL;
using Mis333ksp18Group17.Models;

namespace Mis333ksp18Group17.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        private AppDbContext db = new AppDbContext();

        [Authorize(Roles = "Employee")]
        public ActionResult Index()
        {
            return View(db.Users.ToList().Where(o=>o.Number != 0).OrderBy(o=>o.Number));
        }

        public ActionResult CustomerProfile()
        {
            String UserId = User.Identity.GetUserId();
            AppUser app = db.Users.Find(UserId);
            return View(app);
        }

        // GET: Customers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser appUser = db.Users.Find(id);
            if (appUser == null)
            {
                return HttpNotFound();
            }
            if(User.IsInRole ("Employee") || appUser.Id == User.Identity.GetUserId())
            {
                return View(appUser);
            }

            else
            {
                return View("Error", new string[] { "This is not your profile" });
            }
        }

        [Authorize(Roles = "Employee")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Number,FirstName,LastName,MiddleInitial,Birthday,Street,City,State,ZipCode,Email,PhoneNumber")] AppUser appUser)
        {
            //if (appUser.Birthday.AddYears(13) > DateTime.Today)
            //{
            //    ViewBag.ErrorC= "The user need to at least 13 years old to register";
            //    return View("CustomerError");
            //}

            if (ModelState.IsValid)
            {
                //TODO: Add fields to user here so they will be saved to do the database
                var user = new AppUser
                {
                    Number = Utilities.GenerateCustomerNumber.GetNextCustomerNumber(),
                    UserName = appUser.Email,
                    Email = appUser.Email,
                    //Firstname is an example - you will need to add the rest
                    FirstName = appUser.FirstName,
                    LastName = appUser.LastName,
                    MiddleInitial = appUser.MiddleInitial,
                    Birthday = appUser.Birthday,
                    Street = appUser.Street,
                    City = appUser.City,
                    State = appUser.State,
                    ZipCode = appUser.ZipCode,
                    SSN = appUser.SSN,
                    PhoneNumber = appUser.PhoneNumber,
                    PopcornPoints = appUser.PopcornPoints
                };
                return RedirectToAction("Index");
            }

            return View(appUser);
        }

        
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser appUser = db.Users.Find(id);
            if (appUser == null)
            {
                return HttpNotFound();
            }
            if (User.IsInRole("Employee") || appUser.Id == User.Identity.GetUserId())
            {
                return View(appUser);
            }

            else
            {
                return View("Error", new string[] { "This is not your profile" });
            }
           
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Number,FirstName, LastName,MiddleInitial,Birthday,Street,City,State,ZipCode,PhoneNumber, Type,PopcornPoints")] AppUser appUser)
        {
            AppUser CustomerToEdit = db.Users.Find(appUser.Id);
            
            if (ModelState.IsValid)
            {             
                CustomerToEdit.Number = appUser.Number;
                CustomerToEdit.FirstName = appUser.FirstName;
                CustomerToEdit.LastName = appUser.LastName;
                CustomerToEdit.Birthday = appUser.Birthday;
                CustomerToEdit.MiddleInitial = appUser.MiddleInitial;
                CustomerToEdit.Street = appUser.Street;
                CustomerToEdit.City = appUser.City;
                CustomerToEdit.PhoneNumber = appUser.PhoneNumber;
                CustomerToEdit.PopcornPoints = appUser.PopcornPoints;
                CustomerToEdit.Type = appUser.Type;
                CustomerToEdit.ZipCode = appUser.ZipCode;
                CustomerToEdit.State = appUser.State;
                db.Entry(CustomerToEdit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CustomerProfile");
            }
            return View(appUser);
        }

        //// GET: Customers/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AppUser appUser = db.Users.Find(id);
        //    if (appUser == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(appUser);
        //}

        //// POST: Customers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    AppUser appUser = db.Users.Find(id);
        //    db.Users.Remove(appUser);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
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
