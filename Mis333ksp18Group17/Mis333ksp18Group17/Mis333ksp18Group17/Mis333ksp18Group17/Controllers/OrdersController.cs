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
using System.Net.Mail;


namespace Mis333ksp18Group17.Controllers
{
    public enum PaymentMethod { CreditCard, PopcornPoints}
    public enum Confirm { Yes, No }
    public class OrdersController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Orders
        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,OrderNumber,OrderDate, Notes, CheckOutStatus")] Order order)
        {
            order.OrderNumber = Utilities.GenerateNextOrderNumber.GetNextOrderNumber();
            order.CheckOutStatus = false;
            order.OrderDate = DateTime.Today;
            order.AppUser = db.Users.Find(User.Identity.GetUserId());
            db.SaveChanges();

            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();

                // direct them to a view that will allow them to add a product to the order 
                return RedirectToAction("AddToOrder", new { OrderID = order.OrderID });
            }

            //ViewBag.AllShowings = GetAllShowings();
            return View(order);

        }

        public ActionResult AddToOrder(int OrderID)
        {
            //Create a new instance of the registration detail class
            OrderDetail od = new OrderDetail();

            //Find the registration for this order detail
            Order order = db.Orders.Find(OrderID);

            //Set the new registration detail's registration to the new reg we just found
            od.Order = order;

          
            //Populate the view bag with the list of courses
            ViewBag.AllShowings = GetAllShowings();           
            //Give the view the registration detail object we just created
            return View(od);
        }

        [HttpPost]
        public ActionResult AddToOrder(OrderDetail od, int SelectedShowings)
        {
            Showing showing = db.Showings.Find(SelectedShowings);
            od.Showing = showing;       
            Order order = db.Orders.Find(od.Order.OrderID);
        
            od.Order = order;


            //od.MoviePrice = showing.MoviePrice;
            od.MoviePrice = GetPrice(od);
            od.TotalPrice = od.MoviePrice * od.Quantity;
         
            if (ModelState.IsValid)//model meets all requirements
            {
                db.OrderDetails.Add(od);
                db.SaveChanges();
                return RedirectToAction("SelectSeat", "Orders", new { id = od.OrderDetailID });
            }

            //model state is not valid
            ViewBag.AllShowings = GetAllShowings();
            return View(od);

        }

        public ActionResult SelectSeat(int id)
        {
            //Create a new instance of the registration detail class
            //Find the registration for this order detail
            Order order = db.Orders.Find(id);

            //Set the new registration detail's registration to the new reg we just found
            OrderDetail od = db.OrderDetails.Find(id);
            Showing showing = db.Showings.Find(od.Showing.ShowingID);
            for (int i = 0; i < od.Quantity; i++)
            {          
                //Populate the view bag with the list of courses      
                ViewBag.GetAvaiableSeats = FindAvailableSeats(showing);
                //Give the view the registration detail object we just created
                
            }
            return View(od);
        }



        [HttpPost]
        public ActionResult SelectSeat([Bind(Include = "OrderDetailID,SeatAssignment")] OrderDetail od, int SelectedSeat)
        {
      
                String Seat = GetSeatName(SelectedSeat);

                OrderDetail orderDetail = db.OrderDetails.Find(od.OrderDetailID);
                orderDetail.SeatAssignment = Seat;
                Order order = orderDetail.Order;

                db.Entry(orderDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Orders", new { id = order.OrderID });
                      
        }
        //[HttpPost]
        //public ActionResult SelectSeat(OrderDetail od, int SelectedSeat)
        //{          
        //    String Seat = GetSeatName(SelectedSeat);

        //    OrderDetail orderDetail = db.OrderDetails.Find(od.OrderDetailID);

        //    orderDetail.SeatAssignment = Seat;
        //    Order order = db.Orders.Find(od.Order.OrderID);            
        //    //od.MoviePrice = showing.MoviePrice;
        //    //od.MoviePrice = GetPrice(od);
        //    //od.TotalPrice = od.MoviePrice * od.Quantity;

        //    //if (ModelState.IsValid)//model meets all requirements
        //    //{
        //    //    db.OrderDetails.Add(od);
        //    db.SaveChanges();
        //    return RedirectToAction("Details", "Orders", new { id = order.OrderID });
        //    //}

        //    ////model state is not valid;
        //    //ViewBag.GetAvaiableSeats = FindAvailableSeats(od);
        //    //return View(od);

        //}


        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,OrderNumber,OrderDate, Notes")] Order order)
        {
            if (ModelState.IsValid)
            {
                Order orderToChange = db.Orders.Find(order.OrderID);
                orderToChange.Notes = order.Notes;

                db.Entry(orderToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }


        // Get action 
        public ActionResult RemoveFromOrder(int OrderID)
        {
            Order order = db.Orders.Find(OrderID);

            if (order == null)//not found
            {
                return RedirectToAction("Details", new { id = OrderID });
            }

            if (order.OrderDetails.Count == 0) // there are no details
            {
                return RedirectToAction("Details", new { id = OrderID });
            }

            //pass the list of order details to the view
            return View(order.OrderDetails);
        }

        // checkout action 
        public ActionResult CheckOutMethod(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
           
            return View(order);
        }

        //[HttpPost, ActionName("Check Out")]
        //[ValidateAntiForgeryToken]
        //public ActionResult CheckOutMethod([Bind(Include = "OrderID,CardHolder,CardType,CreditCardNumber,ExpirationDate")] Order order, PaymentMethod SelectedPaymentMethod, int SelectedCard)
        //{
        //    Order orderToChange = db.Orders.Find(order.OrderID);
        //    CreditCard cd = db.CreditCards.Find(SelectedCard);        
        //    orderToChange.CardHolder = cd.CardHolder;
        //        orderToChange.CardType = cd.CardTypes;
        //        orderToChange.CreditCardNumber = cd.CreditCardNumber;
        //        orderToChange.ExpirationDate = cd.ExpirationDate;

        //        db.Entry(orderToChange).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");




        // //   return View(order);
        //}
        public ActionResult CreditCardCheckOut(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.allCards = GetAllCards(order);
            return View(order);
        }

        [HttpPost]
        public ActionResult CreditCardCheckOut([Bind(Include = "OrderID,CreditCardNumber,CardType,ExpirationDate,CardHolder")] Order order, int SelectedCard)
        {
            if (ModelState.IsValid)
            {
                Order orderToChange = db.Orders.Find(order.OrderID);
                CreditCard cd = db.CreditCards.Find(SelectedCard);
                orderToChange.CreditCardNumber = cd.CreditCardNumber;             
                orderToChange.ExpirationDate = cd.ExpirationDate;
                orderToChange.CardHolder = cd.CardHolder;
                db.Entry(orderToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CheckOut", new { id = orderToChange.OrderID});
            }
            return View(order);
        }

        public ActionResult OtherCheckOut(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }            
            return View(order);
        }

        [HttpPost]
        public ActionResult OtherCheckOut([Bind(Include = "OrderID,CreditCardNumber,CardType,ExpirationDate,CardHolder")] Order order)
        {
            if (ModelState.IsValid)
            {
                Order orderToChange = db.Orders.Find(order.OrderID);
                orderToChange.CreditCardNumber = order.CreditCardNumber;
                orderToChange.ExpirationDate = order.ExpirationDate;
                orderToChange.CardHolder = order.CardHolder;
               
                db.Entry(orderToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CheckOut", new { id = orderToChange.OrderID });
            }
            return View(order);
        }


       

        public ActionResult CheckOut(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }          
            return View(order);
        }

        [HttpPost]
        public ActionResult CheckOut([Bind(Include = "OrderID, CheckOutStatus")] Order order, Confirm Confirm)
        {
            Order orderToChange = db.Orders.Find(order.OrderID);

            if (Confirm == Confirm.Yes)
            {
                orderToChange.CheckOutStatus = true;
                Int32 Price = Decimal.ToInt32(orderToChange.TotalBeforeTax);
                orderToChange.AppUser.PopcornPoints = orderToChange.AppUser.PopcornPoints + Price;
                db.Entry(orderToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Summary", new { id = order.OrderID });
            }
            else
            {
                orderToChange.CheckOutStatus = false;
                db.Entry(orderToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
        }


        public ActionResult Popcorn(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [HttpPost]
        public ActionResult Popcorn([Bind(Include = "OrderID, CheckOutStatus")] Order order, Confirm Confirm)
        {
            Order orderToChange = db.Orders.Find(order.OrderID);

            if (Confirm == Confirm.Yes)
            {
                orderToChange.CheckOutStatus = true;
                
                String UserID = User.Identity.GetUserId();
                Int32 quantity = orderToChange.OrderDetails.Count();
                AppUser AppUser = db.Users.Find(UserID);
                Int32 popcornBalance = AppUser.PopcornPoints;
                if (quantity * 100 < popcornBalance) {
                    orderToChange.AppUser.PopcornPoints = orderToChange.AppUser.PopcornPoints - quantity *100;
                    db.Entry(orderToChange).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("SummaryForPop", new { id = order.OrderID });
                }
                else
                {
                    ViewBag.Error = "Insufficient Popcorn Points";
                    return View("Error");
                }
            
            }
            else
            {
                orderToChange.CheckOutStatus = false;
                db.Entry(orderToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }

        public ActionResult Summary(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            String s = "Order Confirmation" + "\n" + "Confirmation Number:" +"\n\n";
            List<OrderDetail> ods = order.OrderDetails;
            foreach (OrderDetail od in ods)
            {
                s = s + "Movie Title:" + od.Showing.Movie.Title +"\n"
                    + "Showing Time:" + od.Showing.StartTime + "\n"
                    + "Seat:" + od.SeatAssignment + "\n"
                    + "Movie Price:" + od.MoviePrice.ToString("C") + "\n\n";     
            }

            s = s + "Subtotal:" + order.TotalBeforeTax.ToString("C") + "\n"
                 + "Sales Tax:" + order.SalesTax.ToString("C") + "\n"
                 + "Total Price" + order.TotalPrice.ToString("C") + "\n" ;
            SendEmail(order.AppUser.Email, "Order Confirmation", s);
            return View(order);
           
        }


        public ActionResult SummaryForPop(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            String s = "Order Confirmation" + "\n" + "Confirmation Number:" + "\n\n";
            List<OrderDetail> ods = order.OrderDetails;
            foreach (OrderDetail od in ods)
            {
                s = s + "Movie Title:" + od.Showing.Movie.Title + "\n"
                    + "Showing Time:" + od.Showing.StartTime + "\n"
                    + "Seat:" + od.SeatAssignment + "\n"
                    + "Movie Price:" + od.MoviePrice.ToString("C") + "\n\n";
            }

            s = s + "Popcorn Used:" + (ods.Count() * 100).ToString() + "\n"
                  + "Popcorn Balance:" + order.AppUser.PopcornPoints.ToString();
            SendEmail(order.AppUser.Email, "Order Confirmation", s);
            return View(order);
        }






        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public SelectList GetAllCards(Order order)
        {
            String UserID = User.Identity.GetUserId();
            List<CreditCard> allCards = db.CreditCards.Where( c => c.AppUser.Id == UserID).ToList();

            //convert the list to a select list
            SelectList selCredits = new SelectList(allCards, "CreditCardID", "CreditCardNumber");

            //return the select list
            return selCredits;
        }
        public SelectList FindAvailableSeats(Showing showing) //tickets is the list of 
        {
            //OrderDetail od = db.OrderDetails.Find(OrderDetail.OrderDetailID);
            //Showing showing = od.Showing;

            //Seat s = new Seat();
            //List<Seat> TakenSeats = new List<Seat>();

            //s.SeatName = OrderDetail.SeatAssignment;
            //s.SeatID = GetSeatID(s.SeatName);
            //TakenSeats.Add(s);

            List<Seat> AvailableSeats = new List<Seat>();
            AvailableSeats = GetAllSeats().Except(TakenSeat(showing)).ToList();
        
            SelectList slAvailableSeats = new SelectList(AvailableSeats, "SeatID", "SeatName");
            return slAvailableSeats;

        }

        public List<Seat> TakenSeat(Showing showing)
        {
            List<Seat> TakenSeats = new List<Seat>();

            //var query = from s in db.OrderDetails
            //              select s;

            //query = query.Where(s => s.Showing.ShowingID == showing.ShowingID);


            //List<OrderDetail> ods = query.ToList();
            List<OrderDetail> ods = showing.OrderDetails;
            foreach (OrderDetail od in ods)
            {
                Seat s = new Seat();
                s.SeatName = od.SeatAssignment;
                s.SeatID = GetSeatID(s.SeatName);
                TakenSeats.Add(s);
            }
            return TakenSeats;

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
            if (SeatId == 0 )
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
        //method to get all products for the ViewBag
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
            if (od.Showing.Date.DayOfWeek.ToString() == "Monday" || od.Showing.Date.DayOfWeek.ToString() == "Wendesday" || od.Showing.Date.DayOfWeek.ToString() == "Thursday")
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
