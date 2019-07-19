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
    public class SeatsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Seats
        public ActionResult Index()
        {
            return View(db.Seats.ToList());
        }

        // GET: Seats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seat seat = db.Seats.Find(id);
            if (seat == null)
            {
                return HttpNotFound();
            }
            return View(seat);
        }

        // GET: Seats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SeatID,SeatName")] Seat seat)
        {
            if (ModelState.IsValid)
            {
                db.Seats.Add(seat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(seat);
        }

        // GET: Seats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seat seat = db.Seats.Find(id);
            if (seat == null)
            {
                return HttpNotFound();
            }
            return View(seat);
        }

        // POST: Seats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SeatID,SeatName")] Seat seat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seat);
        }

        // GET: Seats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seat seat = db.Seats.Find(id);
            if (seat == null)
            {
                return HttpNotFound();
            }
            return View(seat);
        }


        public SelectList FindAvailableSeats(List<OrderDetail> OrderDetails) //tickets is the list of 
        {
            List<Seat> TakenSeats = new List<Seat>();

            foreach (OrderDetail od in OrderDetails)
            {
                Seat s = new Seat();
                s.SeatName = od.SeatAssignment;
                s.SeatID = GetSeatID(s.SeatName);
                TakenSeats.Add(s);
            }

            List<Seat> AvailableSeats = GetAllSeats().Except(TakenSeats).ToList();

            SelectList slAvailableSeats = new SelectList(AvailableSeats, "SeatID", "SeatName");
            return slAvailableSeats;

        }


        public List<Seat> GetAllSeats()
        {
            List<Seat> AllSeats = new List<Seat>();

            Seat s1 = new Seat() { SeatID = 0, SeatName = "1A" };
            AllSeats.Add(s1);

            Seat s2 = new Seat() { SeatID = 0, SeatName = "1B" };
            AllSeats.Add(s2);

            Seat s3 = new Seat() { SeatID = 0, SeatName = "1C" };
            AllSeats.Add(s3);

            Seat s4 = new Seat() { SeatID = 0, SeatName = "1D" };
            AllSeats.Add(s4);

            Seat s5 = new Seat() { SeatID = 0, SeatName = "2A" };
            AllSeats.Add(s5);

            Seat s6 = new Seat() { SeatID = 0, SeatName = "2B" };
            AllSeats.Add(s6);

            Seat s7 = new Seat() { SeatID = 0, SeatName = "2C" };
            AllSeats.Add(s7);

            Seat s8 = new Seat() { SeatID = 0, SeatName = "2D" };
            AllSeats.Add(s8);

            Seat s9 = new Seat() { SeatID = 0, SeatName = "3A" };
            AllSeats.Add(s9);

            Seat s10 = new Seat() { SeatID = 0, SeatName = "3B" };
            AllSeats.Add(s10);

            Seat s11 = new Seat() { SeatID = 0, SeatName = "3C" };
            AllSeats.Add(s11);

            Seat s12 = new Seat() { SeatID = 0, SeatName = "3D" };
            AllSeats.Add(s12);

            Seat s13 = new Seat() { SeatID = 0, SeatName = "4A" };
            AllSeats.Add(s13);

            Seat s14 = new Seat() { SeatID = 0, SeatName = "4B" };
            AllSeats.Add(s14);

            Seat s15 = new Seat() { SeatID = 0, SeatName = "4C" };
            AllSeats.Add(s15);

            Seat s16 = new Seat() { SeatID = 0, SeatName = "4D" };
            AllSeats.Add(s16);

            Seat s17 = new Seat() { SeatID = 0, SeatName = "5A" };
            AllSeats.Add(s17);

            Seat s18 = new Seat() { SeatID = 0, SeatName = "5B" };
            AllSeats.Add(s18);

            Seat s19 = new Seat() { SeatID = 0, SeatName = "5C" };
            AllSeats.Add(s19);

            Seat s20 = new Seat() { SeatID = 0, SeatName = "5D" };
            AllSeats.Add(s20);

            Seat s21 = new Seat() { SeatID = 0, SeatName = "6A" };
            AllSeats.Add(s21);

            Seat s22 = new Seat() { SeatID = 0, SeatName = "6B" };
            AllSeats.Add(s22);

            Seat s23 = new Seat() { SeatID = 0, SeatName = "6C" };
            AllSeats.Add(s23);

            Seat s24 = new Seat() { SeatID = 0, SeatName = "6D" };
            AllSeats.Add(s24);

            Seat s25 = new Seat() { SeatID = 0, SeatName = "7A" };
            AllSeats.Add(s25);

            Seat s26 = new Seat() { SeatID = 0, SeatName = "7B" };
            AllSeats.Add(s26);

            Seat s27 = new Seat() { SeatID = 0, SeatName = "7C" };
            AllSeats.Add(s27);

            Seat s28 = new Seat() { SeatID = 0, SeatName = "7D" };
            AllSeats.Add(s28);

            Seat s29 = new Seat() { SeatID = 0, SeatName = "8A" };
            AllSeats.Add(s29);

            Seat s30 = new Seat() { SeatID = 0, SeatName = "8B" };
            AllSeats.Add(s30);

            Seat s31 = new Seat() { SeatID = 0, SeatName = "8C" };
            AllSeats.Add(s31);

            Seat s32 = new Seat() { SeatID = 0, SeatName = "8D" };
            AllSeats.Add(s32);

            return AllSeats;
        }

        public Int32 GetSeatID(String seatName)
        {
            if (seatName == "1A")
                return 0;
            if (seatName == "1B")
                return 1;
            if (seatName == "1C")
                return 2;
            if (seatName == "1D")
                return 3;
            if (seatName == "2A")
                return 4;
            if (seatName == "2B")
                return 5;
            if (seatName == "2C")
                return 6;
            if (seatName == "2D")
                return 7;
            if (seatName == "3A")
                return 8;
            if (seatName == "3B")
                return 9;
            if (seatName == "3C")
                return 10;
            if (seatName == "3D")
                return 11;
            if (seatName == "4A")
                return 12;
            if (seatName == "4B")
                return 13;
            if (seatName == "4C")
                return 14;
            if (seatName == "4D")
                return 15;
            if (seatName == "5A")
                return 16;
            if (seatName == "5B")
                return 17;
            if (seatName == "5C")
                return 18;
            if (seatName == "5D")
                return 19;
            if (seatName == "6A")
                return 20;
            if (seatName == "6B")
                return 21;
            if (seatName == "6C")
                return 22;
            if (seatName == "6D")
                return 23;
            if (seatName == "7A")
                return 24;
            if (seatName == "7B")
                return 25;
            if (seatName == "7C")
                return 26;
            if (seatName == "7D")
                return 27;
            if (seatName == "8A")
                return 28;
            if (seatName == "8B")
                return 29;
            if (seatName == "8C")
                return 30;
            if (seatName == "8D")
                return 31;

            return -1;

        }
        // POST: Seats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seat seat = db.Seats.Find(id);
            db.Seats.Remove(seat);
            db.SaveChanges();
            return RedirectToAction("Index");
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
