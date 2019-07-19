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
using Microsoft.AspNet.Identity;
//public enum PaymentMethod { PopcornPoint,CreditCard}
namespace Mis333ksp18Group17.Controllers
{
    [Authorize]
    public class OrderDetailsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        [Authorize(Roles = "Manager")]
        public ActionResult SummaryReport(String SearchTitle, String SearchFirstName, String SearchLastName, PaymentMethod? Method, DateTime?
            SelectedShowingDate, Classification? SelectedClass1, DateTime? SelectedOrderDate, Classification? SelectedClass2)
        {
            var query = from o in db.OrderDetails
                        select o;

            List<OrderDetail> SelectedOds = new List<OrderDetail>();
            query = query.Where(o => o.Order.CheckOutStatus == true);
            query = query.Where(o => o.Order.CancelStatus == CancelStatus.No);
            if (SearchTitle != null)
            {
                query = query.Where(o => o.Showing.Title.Contains(SearchTitle));
            }

            if (SearchFirstName != null)
            {
                query = query.Where(o => o.Order.AppUser.FirstName.Contains(SearchFirstName));
            }

            if (SearchLastName != null)
            {
                query = query.Where(o => o.Order.AppUser.LastName.Contains(SearchLastName));
            }

            
                switch (Method)
                {
                    case PaymentMethod.PopcornPoints:

                        query = query.Where(o => o.Order.PaymentMethod.ToString() == PaymentMethod.PopcornPoints.ToString());

                        break;
                    case PaymentMethod.CreditCard:

                        query = query.Where(o => o.Order.PaymentMethod.ToString() == PaymentMethod.CreditCard.ToString());

                        break;
                   default:
                     break;

            }
            


            if (SelectedShowingDate != null)
            {

                switch (SelectedClass1)
                {
                    case Classification.After:

                        query = query.Where(o => o.Showing.Date >= SelectedShowingDate);

                        break;
                    case Classification.Before:

                        query = query.Where(o => o.Showing.Date < SelectedShowingDate);

                        break;

                    case Classification.All:
                        break;

                }
            }

            if (SelectedOrderDate != null)
            {

                switch (SelectedClass2)
                {
                    case Classification.After:

                        query = query.Where(o => o.Order.OrderDate >= SelectedOrderDate);

                        break;
                    case Classification.Before:

                        query = query.Where(o => o.Order.OrderDate < SelectedOrderDate);

                        break;
                    case Classification.All:

                       

                        break;
                }
            }
            Decimal Revenue = 0;

            foreach(OrderDetail od in query)
            {
                Revenue = Revenue + od.MoviePrice;
            }
            ViewBag.Revenue = Revenue.ToString();

            SelectedOds = query.ToList();
           
            ViewBag.TotalSeats = db.Showings.Count() * 32;
            ViewBag.SelectedSeats = SelectedOds.Count();

           
            
            
            return View("SummaryReport", SelectedOds);

        }
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
            if (User.IsInRole("Employee") || orderDetail.Order.AppUser.Id == User.Identity.GetUserId())
            {
                
                    List<OrderDetail> ods = orderDetail.Showing.OrderDetails;
                    ViewBag.GetAvaiableSeats = EasyAvailableSeats(ods);
                    ViewBag.AllShowings = GetAllShowings(orderDetail);
                    return View(orderDetail);
            }

            else
            {
                return View("Error", new string[] { "This is not your profile" });

            }
           

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderDetailID,SeatAssignment")] OrderDetail orderDetail, String SelectedSeat)
        {
            //find the product associated with this order
            OrderDetail od = db.OrderDetails.Include(RD => RD.Order)
                                                          .Include(RD => RD.Showing)
                                                          .FirstOrDefault(x => x.OrderDetailID == orderDetail.OrderDetailID);

       
            //Showing showing = db.Showings.Find(SelectedShowings);
            //od.Showing = showing;
           // od.MoviePrice = showing.MoviePrice;
            String Seat = SelectedSeat; 
            od.SeatAssignment = Seat;
            
            //AppUser appuser = od.Order.AppUser;

            //if (appuser.Birthday.AddYears(60) < DateTime.Today)
            //{
            //    if (showing.SpecialEvent == SpecialEvent.Yes)
            //    {
            //        od.MoviePrice = showing.MoviePrice;
            //    }
            //    else
            //    {
            //        int count = od.Order.OrderDetails.Count();

            //        if (count > 2)
            //        {
            //            od.MoviePrice = showing.MoviePrice;
            //        }
            //        else
            //        {
            //            od.MoviePrice = showing.MoviePrice - 2;
            //        }
            //    }
            //}
            //else
            //{
            //    od.MoviePrice = showing.MoviePrice;
            //}
            //od.TotalPrice = od.MoviePrice * od.Quantity;
            //od.DiscountType = GetDiscountTypes(od);
            //Note that the code here as change to mark rd and not registrationDetail as the modified entry
            db.Entry(od).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Details", "Orders", new { id = od.Order.OrderID });
            //}
            //ViewBag.GetAvaiableSeats = FindAvailableSeats(od);
            //orderDetail.Order = od.Order;

            //return View(orderDetail);
        }
        public static string GetDiscountTypes(OrderDetail od)
        {
            string discounttype;
            if (od.Showing.SpecialEvent == SpecialEvent.No)
            {
                if (od.Order.AppUser.Birthday.AddYears(60) < DateTime.Today)
                {
                    discounttype = "Senior Discount";
                }
                else if ((od.Showing.Date.DayOfWeek.ToString() == "Monday" || od.Showing.Date.DayOfWeek.ToString() == "Wendesday" || od.Showing.Date.DayOfWeek.ToString() == "Thursday" || od.Showing.Date.DayOfWeek.ToString() == "Friday") && od.Showing.StartTime.Hour < 12)
                {
                    discounttype = "Matinees Discount";
                }
                else if (od.Showing.Date.DayOfWeek.ToString() == "Tuesday")
                {
                    discounttype = "Tuesday Discount";
                }
                else if (DateTime.Now.AddHours(48) < od.Showing.StartTime)
                {
                    discounttype = "Early Purchase Discount";
                }
                else
                {
                    discounttype = "No Discount Available";
                }
            }
            else
            {
                discounttype = "No Discount Available";
            }

            return discounttype;
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
            if (User.IsInRole("Employee") || od.Order.AppUser.Id == User.Identity.GetUserId())
            {

               
                return View(od);
            }

            else
            {
                return View("Error", new string[] { "This is not your profile" });

            }
           
        }

      
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
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            if (User.IsInRole("Employee") || orderDetail.Order.AppUser.Id == User.Identity.GetUserId())
            {


                return View(orderDetail);
            }

            else
            {
                return View("Error", new string[] { "This is not your profile" });

            }
           
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

        public static SelectList EasyAvailableSeats(List<OrderDetail> ods)
        {
            List<String> TakenSeatNames = new List<String>();
            foreach (OrderDetail od in ods)
            {
                TakenSeatNames.Add(od.SeatAssignment);
            }

            List<String> AllSeatNames = new List<String>();
            AllSeatNames.Add("A1");
            AllSeatNames.Add("A2");
            AllSeatNames.Add("A3");
            AllSeatNames.Add("A4");
            AllSeatNames.Add("A5");
            AllSeatNames.Add("A6");
            AllSeatNames.Add("A7");
            AllSeatNames.Add("A8");
            AllSeatNames.Add("B1");
            AllSeatNames.Add("B2");
            AllSeatNames.Add("B3");
            AllSeatNames.Add("B4");
            AllSeatNames.Add("B5");
            AllSeatNames.Add("B6");
            AllSeatNames.Add("B7");
            AllSeatNames.Add("B8");
            AllSeatNames.Add("C1");
            AllSeatNames.Add("C2");
            AllSeatNames.Add("C3");
            AllSeatNames.Add("C4");
            AllSeatNames.Add("C5");
            AllSeatNames.Add("C6");
            AllSeatNames.Add("C7");
            AllSeatNames.Add("C8");
            AllSeatNames.Add("D1");
            AllSeatNames.Add("D2");
            AllSeatNames.Add("D3");
            AllSeatNames.Add("D4");
            AllSeatNames.Add("D5");
            AllSeatNames.Add("D6");
            AllSeatNames.Add("D7");
            AllSeatNames.Add("D8");
            //Add the rest of the seat names

            List<String> AvailableSeats = AllSeatNames.Except(TakenSeatNames).ToList();

            SelectList slAvailableSeats = new SelectList(AvailableSeats);

            return slAvailableSeats;
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
