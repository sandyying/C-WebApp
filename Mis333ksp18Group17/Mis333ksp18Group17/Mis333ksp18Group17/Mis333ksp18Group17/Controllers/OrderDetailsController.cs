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
    public class OrderDetailsController : Controller
    {
        private AppDbContext db = new AppDbContext();


        // GET: OrderDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.GetAvaiableSeats = FindAvailableSeats(orderDetail);
            ViewBag.AllShowings = GetAllShowings(orderDetail);
            return View(orderDetail);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderDetailID,SeatAssignment ")] OrderDetail orderDetail, int SelectedSeat, int SelectedShowings)
        {
            //find the product associated with this order
            OrderDetail od = db.OrderDetails.Include(RD => RD.Order)
                                                          .Include(RD => RD.Showing)
                                                          .FirstOrDefault(x => x.OrderDetailID == orderDetail.OrderDetailID);

            //if (ModelState.IsValid)
            //{
            //update the number of students             
            //od.MoviePrice = GetPrice(orderDetail);
            ////update the course fee from the related course
            //od.MoviePrice = od.Showing.MoviePrice;

            //update the total fees
            //od.TotalPrice = od.MoviePrice * od.Quantity;
            Showing showing = db.Showings.Find(SelectedShowings);
            od.Showing = showing;
            String Seat = GetSeatName(SelectedSeat);
            od.SeatAssignment = Seat;
             //Note that the code here as change to mark rd and not registrationDetail as the modified entry
            db.Entry(od).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Details", "Orders", new { id = od.Order.OrderID });
            //}
            //ViewBag.GetAvaiableSeats = FindAvailableSeats(od);
            //orderDetail.Order = od.Order;

            //return View(orderDetail);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail od = db.OrderDetails.Find(id);
            if ( od == null)
            {
                return HttpNotFound();
            }
            return View(od);
        }

        //public ActionResult ChooseSeat(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    OrderDetail orderDetail = db.OrderDetails.Find(id);
        //    if (orderDetail == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.GetAvaiableSeats = FindAvailableSeats(orderDetail);
        //    return View(orderDetail);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ChooseSeat([Bind(Include = "OrderDetailID,Quantity,TotalPrice")] OrderDetail orderDetail)
        //{
        //   // find the product associated with this order
        //    OrderDetail od = db.OrderDetails.Include(RD => RD.Order)
        //                                                  .Include(RD => RD.Showing)
        //                                                  .FirstOrDefault(x => x.OrderDetailID == orderDetail.OrderDetailID);

        //    if (ModelState.IsValid)
        //    {
        //        //update the number of students
        //        od.Quantity = orderDetail.Quantity;
        //        od.MoviePrice = GetPrice(orderDetail);
        //        //update the course fee from the related course
        //        od.MoviePrice = od.Showing.MoviePrice;

        //      //  update the total fees
        //        od.TotalPrice = od.MoviePrice * od.Quantity;

        //      //  Note that the code here as change to mark rd and not registrationDetail as the modified entry
        //        db.Entry(od).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Details", "Orders", new { id = od.Order.OrderID });
        //    }

        //    orderDetail.Order = od.Order;
        //    return View(orderDetail);
        //}





        // GET: OrderDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            Order order = orderDetail.Order;
            db.OrderDetails.Remove(orderDetail);
            db.SaveChanges();
            return RedirectToAction("Details","Orders", new { id = order.OrderID });
        }
        Int32 intPrice;
        public Int32 GetPrice(OrderDetail od)
        {


            if (od.Showing.Date.DayOfWeek.ToString() == "Saturday" || od.Showing.Date.DayOfWeek.ToString() == "Sunday")
            {
                intPrice = 12;
            }
            if (od.Showing.Date.DayOfWeek.ToString() == "Friday")
            {
                if (od.Showing.StartTime.Hour > 12)
                {
                    intPrice = 12;
                }
                else
                {
                    intPrice = 5;
                }
            }
            if (od.Showing.Date.DayOfWeek.ToString() == "Monday" || od.Showing.Date.DayOfWeek.ToString() == "Wednesday" || od.Showing.Date.DayOfWeek.ToString() == "Thursday")
            {
                if (od.Showing.StartTime.Hour < 12)
                {
                    intPrice = 5;
                }
                else
                {
                    intPrice = 10;
                }
            }
            if (od.Showing.Date.DayOfWeek.ToString() == "Tuesday")
            {
                if (od.Showing.StartTime.Hour < 17)
                {
                    intPrice = 8;
                }
                else
                {
                    intPrice = 10;
                }

            }

            return intPrice;
        }

        public SelectList FindAvailableSeats(OrderDetail OrderDetail) //tickets is the list of 
        {
            Showing showing = OrderDetail.Showing;

            Seat s = new Seat();
            List<Seat> TakenSeats = new List<Seat>();

            s.SeatName = OrderDetail.SeatAssignment;
            s.SeatID = GetSeatID(s.SeatName);
            TakenSeats.Add(s);
            List<Seat> AvailableSeats = GetAllSeats().Except(TakenSeats).ToList();
            Int32 SelectedSeat = GetSeatID(OrderDetail.SeatAssignment);

            SelectList slAvailableSeats = new SelectList(AvailableSeats, "SeatID", "SeatName", SelectedSeat);
            return slAvailableSeats;

        }


        public List<Seat> GetAllSeats()
        {
            List<Seat> AllSeats = new List<Seat>();

            Seat s1 = new Seat() { SeatID = 0, SeatName = "A1" };
            AllSeats.Add(s1);

            Seat s2 = new Seat() { SeatID = 1, SeatName = "A2" };
            AllSeats.Add(s2);

            Seat s3 = new Seat() { SeatID = 2, SeatName = "A3" };
            AllSeats.Add(s3);

            Seat s4 = new Seat() { SeatID = 3, SeatName = "A4" };
            AllSeats.Add(s4);

            Seat s5 = new Seat() { SeatID = 4, SeatName = "A5" };
            AllSeats.Add(s5);

            Seat s6 = new Seat() { SeatID = 5, SeatName = "A6" };
            AllSeats.Add(s6);

            Seat s7 = new Seat() { SeatID = 6, SeatName = "A7" };
            AllSeats.Add(s7);

            Seat s8 = new Seat() { SeatID = 7, SeatName = "A8" };
            AllSeats.Add(s8);

            Seat s9 = new Seat() { SeatID = 8, SeatName = "B1" };
            AllSeats.Add(s9);

            Seat s10 = new Seat() { SeatID = 9, SeatName = "B2" };
            AllSeats.Add(s10);

            Seat s11 = new Seat() { SeatID = 10, SeatName = "B3" };
            AllSeats.Add(s11);

            Seat s12 = new Seat() { SeatID = 11, SeatName = "B4" };
            AllSeats.Add(s12);

            Seat s13 = new Seat() { SeatID = 12, SeatName = "B5" };
            AllSeats.Add(s13);

            Seat s14 = new Seat() { SeatID = 13, SeatName = "B6" };
            AllSeats.Add(s14);

            Seat s15 = new Seat() { SeatID = 14, SeatName = "B7" };
            AllSeats.Add(s15);

            Seat s16 = new Seat() { SeatID = 15, SeatName = "B8" };
            AllSeats.Add(s16);

            Seat s17 = new Seat() { SeatID = 16, SeatName = "C1" };
            AllSeats.Add(s17);

            Seat s18 = new Seat() { SeatID = 17, SeatName = "C2" };
            AllSeats.Add(s18);

            Seat s19 = new Seat() { SeatID = 18, SeatName = "C3" };
            AllSeats.Add(s19);

            Seat s20 = new Seat() { SeatID = 19, SeatName = "C4" };
            AllSeats.Add(s20);

            Seat s21 = new Seat() { SeatID = 20, SeatName = "C5" };
            AllSeats.Add(s21);

            Seat s22 = new Seat() { SeatID = 21, SeatName = "C6" };
            AllSeats.Add(s22);

            Seat s23 = new Seat() { SeatID = 22, SeatName = "C7" };
            AllSeats.Add(s23);

            Seat s24 = new Seat() { SeatID = 23, SeatName = "C8" };
            AllSeats.Add(s24);

            Seat s25 = new Seat() { SeatID = 24, SeatName = "D1" };
            AllSeats.Add(s25);

            Seat s26 = new Seat() { SeatID = 25, SeatName = "D2" };
            AllSeats.Add(s26);

            Seat s27 = new Seat() { SeatID = 26, SeatName = "D3" };
            AllSeats.Add(s27);

            Seat s28 = new Seat() { SeatID = 27, SeatName = "D4" };
            AllSeats.Add(s28);

            Seat s29 = new Seat() { SeatID = 28, SeatName = "D5" };
            AllSeats.Add(s29);

            Seat s30 = new Seat() { SeatID = 29, SeatName = "D6" };
            AllSeats.Add(s30);

            Seat s31 = new Seat() { SeatID = 30, SeatName = "D7" };
            AllSeats.Add(s31);

            Seat s32 = new Seat() { SeatID = 31, SeatName = "D8" };
            AllSeats.Add(s32);

            return AllSeats;
        }

        public String GetSeatName(Int32 SeatId)
        {
            if (SeatId == 0)
                return "A1";
            if (SeatId == 1)
                return "A2";
            if (SeatId == 2)
                return "A3";
            if (SeatId == 3)
                return "A4";
            if (SeatId == 4)
                return "A5";
            if (SeatId == 5)
                return "A6";
            if (SeatId == 6)
                return "A7";
            if (SeatId == 7)
                return "A8";
            if (SeatId == 8)
                return "B1";
            if (SeatId == 9)
                return "B2";
            if (SeatId == 10)
                return "B3";
            if (SeatId == 11)
                return "B4";
            if (SeatId == 12)
                return "B5";
            if (SeatId == 13)
                return "B6";
            if (SeatId == 14)
                return "B7";
            if (SeatId == 15)
                return "B8";
            if (SeatId == 16)
                return "C1";
            if (SeatId == 17)
                return "C2";
            if (SeatId == 18)
                return "C3";
            if (SeatId == 19)
                return "C4";
            if (SeatId == 20)
                return "C5";
            if (SeatId == 21)
                return "C6";
            if (SeatId == 22)
                return "C7";
            if (SeatId == 23)
                return "C8";
            if (SeatId == 24)
                return "D1";
            if (SeatId == 25)
                return "D2";
            if (SeatId == 26)
                return "D3";
            if (SeatId == 27)
                return "D4";
            if (SeatId == 28)
                return "D5";
            if (SeatId == 29)
                return "D6";
            if (SeatId == 30)
                return "D7";
            if (SeatId == 31)
                return "D8";
            return "Not Available";

        }

        public Int32 GetSeatID(String seatName)
        {
            if (seatName == "A1")
                return 0;
            if (seatName == "A2")
                return 1;
            if (seatName == "A3")
                return 2;
            if (seatName == "A4")
                return 3;
            if (seatName == "A5")
                return 4;
            if (seatName == "A6")
                return 5;
            if (seatName == "A7")
                return 6;
            if (seatName == "A8")
                return 7;
            if (seatName == "B1")
                return 8;
            if (seatName == "B2")
                return 9;
            if (seatName == "B3")
                return 10;
            if (seatName == "B4")
                return 11;
            if (seatName == "B5")
                return 12;
            if (seatName == "B6")
                return 13;
            if (seatName == "B7")
                return 14;
            if (seatName == "B8")
                return 15;
            if (seatName == "C1")
                return 16;
            if (seatName == "C2")
                return 17;
            if (seatName == "C3")
                return 18;
            if (seatName == "C4")
                return 19;
            if (seatName == "C5")
                return 20;
            if (seatName == "C6")
                return 21;
            if (seatName == "C7")
                return 22;
            if (seatName == "C8")
                return 23;
            if (seatName == "D1")
                return 24;
            if (seatName == "D2")
                return 25;
            if (seatName == "D3")
                return 26;
            if (seatName == "D4")
                return 27;
            if (seatName == "D5")
                return 28;
            if (seatName == "D6")
                return 29;
            if (seatName == "D7")
                return 30;
            if (seatName == "D8")
                return 31;
            return -1;

        }
        public SelectList GetAllShowings()
        {

            var query = from s in db.Showings
                        select s;

            query = query.Where(s => s.Pending.ToString() == "No");
            List<Showing> allShowings = query.OrderBy(c => c.Movie.Title).ToList();

            //convert the list to a select list
            SelectList selShowings = new SelectList(allShowings, "ShowingID", "MovieAndDate");

            //return the select list
            return selShowings;
        }

        public SelectList GetAllShowings(OrderDetail od)
        {
            var query = from s in db.Showings
                        select s;
            query = query.Where(s => s.Pending.ToString() == "No");
            List<Showing> allShowings = query.OrderBy(c => c.Movie.Title).ToList();


            // List<Int32> SelectedMovies = new List<Int32>();           
            Int32 SelectedShowings = od.Showing.ShowingID;
            SelectList selshowings = new SelectList(allShowings, "ShowingID", "MovieAndDate", SelectedShowings);


            return selshowings;
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
