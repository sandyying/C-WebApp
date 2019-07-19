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
    public enum PaymentMethod { CreditCard, PopcornPoints, All}
    public enum Confirm { Yes, No }
    public enum Gift { Yes, No}
    [Authorize]
    public class OrdersController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Orders
        public ActionResult Index()
        {
            if (User.IsInRole("Employee"))
            {
                return View(db.Orders.ToList());
            }

            else
            {
                String UserID = User.Identity.GetUserId();
                List<Order> Orders = db.Orders.Where(o => o.AppUser.Id == UserID).ToList();
                return View(Orders);
            }
        }
        

        public ActionResult OrderHistory(PaymentMethod? Method)
        {
            var query = from o in db.Orders
                        select o;


            switch (Method)
            {
                case PaymentMethod.PopcornPoints:

                    query = query.Where(o => o.PaymentMethod.ToString() == PaymentMethod.PopcornPoints.ToString());

                    break;
                case PaymentMethod.CreditCard:

                    query = query.Where(o => o.PaymentMethod.ToString() == PaymentMethod.CreditCard.ToString());

                    break;
                default:
                    break;

            }
                     
            
                String UserID = User.Identity.GetUserId();
                List<Order> Orders = query.Where(o => o.AppUser.Id == UserID && o.CheckOutStatus == true).ToList();
                return View(Orders);
            
            //List<AppUser> appuser = query.ToList();
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

            if (User.IsInRole("Employee") || order.AppUser.Id == User.Identity.GetUserId())
            {

                return View(order);
            }
            else
            {
                return View("Error", new string[] { "This is not your order!!" });
            }
        }

        // GET: Orders/Create
        [Authorize]
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

        [Authorize]
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
            od.MoviePrice = showing.MoviePrice;
            od.Order = order;
            AppUser appuser = order.AppUser;
            
            if (appuser.Birthday.AddYears(60) < DateTime.Today)
            {
                if (showing.SpecialEvent == SpecialEvent.Yes)
                {
                    od.MoviePrice = showing.MoviePrice;
                }
                else
                {
                    int count = order.OrderDetails.Count();

                    if (count >= 2)
                    {
                        od.MoviePrice = showing.MoviePrice;
                    }
                    else
                    {
                        od.MoviePrice = od.MoviePrice - 2;
                    }
                }
            }

            if (DateTime.Now.AddHours(48) < od.Showing.StartTime)
            {
                if (showing.SpecialEvent == SpecialEvent.Yes)
                {
                    od.MoviePrice = od.MoviePrice;
                }
                else
                {
                    od.MoviePrice = od.MoviePrice - 1;
                }
            }

            
            od.TotalPrice = od.MoviePrice * od.Quantity;
            od.DiscountType = GetDiscountTypes(od);

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
        [Authorize]
        public ActionResult SelectSeat(int id)
        {
           
            OrderDetail od = db.OrderDetails.Find(id);
            //Order order = od.Order;
            Showing showing = od.Showing;
            List<OrderDetail> ods = showing.OrderDetails.Where(oo=>oo.Order.CancelStatus == CancelStatus.No).ToList();                  
            ViewBag.GetAvaiableSeats = EasyAvailableSeats(ods);
      
            return View(od);
        }



        [HttpPost]
        public ActionResult SelectSeat([Bind(Include = "OrderDetailID,SeatAssignment")] OrderDetail od, string SelectedSeat)
        {
            OrderDetail orderDetail = db.OrderDetails.Find(od.OrderDetailID);
            Order order = orderDetail.Order;
            if (SelectedSeat == null)
            {
                ViewBag.Error = "No Seat Available. You need to select a seat";
                ViewBag.AllShowings = GetAllShowings();
                return RedirectToAction("AddToOrder", "Orders", new { OrderID = order.OrderID });
            }
            else
            {
                orderDetail.SeatAssignment = SelectedSeat;
                db.Entry(orderDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Orders", new { id = order.OrderID });
            }
        }
     

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

            if (User.IsInRole("Employee") || order.AppUser.Id == User.Identity.GetUserId())
            {

                return View(order);
            }
            else
            {
                return View("Error", new string[] { "This is not your order!!" });
            }

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

            if (User.IsInRole("Employee") || order.AppUser.Id == User.Identity.GetUserId())
            {

                return View(order.OrderDetails);
            }
            else
            {
                return View("Error", new string[] { "This is not your order!!" });
            }
        }

        // checkout action 
        [Authorize]
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
            //if (order.OrderDetails.Count() == 0)
            //{
            //    ViewBag.Error = "You must choose what to purchase first";
            //    return View("Error");
            //}

            //List<OrderDetail> ods = order.OrderDetails;
            //for (int i = 0; i < ods.Count(); i++)
            //{
            //    for (int j = i + 1; j < ods.Count(); j++)
            //    {
            //        if (ods[i].Showing.Title == ods[j].Showing.Title)
            //            if (ods[i].Showing.Date != ods[j].Showing.Date)
            //            {
            //                ViewBag.Error = "You need to create a separate transaction.";
            //                return View("Error");
            //            }
            //    }
            //}

            //List<OrderDetail> ods1 = order.OrderDetails.OrderBy(o => o.Showing.StartTime).ToList();

            //foreach (OrderDetail od in ods1)
            //{
            //    if (od.Showing.StartTime < DateTime.Now)
            //    {
            //        ViewBag.Error = "You can't purchase a ticket that already started.";
            //        return View("Error");
            //    }
            //}

            //for (int k = 0; k < ods1.Count(); k++)
            //{
            //    for (int q = k + 1; q < ods1.Count(); q++)
            //    {
            //        if (ods1[k].Showing.Title != ods1[q].Showing.Title)
            //            if (ods1[k].Showing.EndTime > ods1[q].Showing.StartTime)
            //            {
            //                ViewBag.Error = "You can't purchase movies that overlap times.";
            //                return View("Error");
            //            }
            //    }
            //}


            //AppUser appuser = order.AppUser;
            //if (appuser.Birthday.AddYears(18) > DateTime.Today)
            //{
            //    foreach (OrderDetail od in ods1)
            //    {
            //        if (od.Showing.Movie.MPAARating == enumMPAARating.NC17 || od.Showing.Movie.MPAARating == enumMPAARating.R)
            //        {
            //            ViewBag.Error = "You can't purchase NC17 or R.";
            //            return View("Error");
            //        }
            //    }
            //}
            return View(order);
        }

        [Authorize]
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
            if (User.IsInRole("Employee") || order.AppUser.Id == User.Identity.GetUserId())
            {

                ViewBag.allCards = GetAllCards(order);
                return View(order);
            }
            else
            {
                return View("Error", new string[] { "This is not your order!!" });
            }
           
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
                orderToChange.CardType = cd.CardTypes;
                db.Entry(orderToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CheckOut", new { id = orderToChange.OrderID});
            }

            return View(order);
        }

        [Authorize]
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
            if (User.IsInRole("Employee") || order.AppUser.Id == User.Identity.GetUserId())
            {

                return View(order);
            }
            else
            {
                return View("Error", new string[] { "This is not your order!!" });
            }
        }

        [HttpPost]
        public ActionResult OtherCheckOut([Bind(Include = "OrderID,CreditCardNumber,CardType,ExpirationDate,CardHolder")] Order order)
        {
            Order orderToChange = db.Orders.Find(order.OrderID);
            if (order.CreditCardNumber == null)
            {
                ViewBag.Error = "Credit Card is Required";
                return View(order);
            }

            if (order.CreditCardNumber != null)
            {
                foreach (char c in order.CreditCardNumber)
                {
                    if (c <'0' || c >'9')
                    {
                        ViewBag.Error = "Please enter all digits";
                        return View(order);
                    }
                }
                if (order.CreditCardNumber.Length != 15 & order.CreditCardNumber.Length != 16)
                {
                    ViewBag.Error = "Please enter 15 or 16 digits card number";
                    return View(order);
                }
                else
                {
                    if (order.CreditCardNumber.Length == 16)
                    {
                        if (order.CreditCardNumber[0] != '4' & order.CreditCardNumber[0] != '6' & (order.CreditCardNumber[0] != '5' && order.CreditCardNumber[1] != '4'))
                        {
                            ViewBag.Error = "Invalid Credit Card";
                            return View(order);
                        }
                        else
                        {
                            if (order.CreditCardNumber[0] == '4')
                            {
                                order.CardType = "Visa";
                            }
                            else if (order.CreditCardNumber[0] == '6')
                            {
                                order.CardType = "Discover";
                            }
                            else
                            {
                                order.CardType = "MasterCard";
                            }
                        }
                    }
                    else
                    {
                        order.CardType = "American Express";
                    }
                
                 }
            }

            

            if (order.ExpirationDate == null)
            {
                ViewBag.Message1 = "Expiration date is Required";
                return View(order);
            }
            else
            {
                if (order.ExpirationDate < DateTime.Today)
                {
                    ViewBag.Message1 = "Must be a future date";
                    return View(order);

                }
            }

            if (order.CardHolder == null)
            {
                ViewBag.Message2 = "Card Holder is required";
                return View(order);
            }
                    orderToChange.CardType = order.CardType;
                    orderToChange.CreditCardNumber = order.CreditCardNumber;
                    if (orderToChange.CreditCardNumber.Length == 16)
                    {
                        Int32 length = orderToChange.CreditCardNumber.Length;
                        orderToChange.CreditCardNumber = "************" + orderToChange.CreditCardNumber[length - 4] + orderToChange.CreditCardNumber[length - 3] + orderToChange.CreditCardNumber[length - 2] + orderToChange.CreditCardNumber[length - 1];
                    }

                    if (orderToChange.CreditCardNumber.Length == 15)
                    {
                        Int32 length = orderToChange.CreditCardNumber.Length;
                        orderToChange.CreditCardNumber = "***********" + orderToChange.CreditCardNumber[length - 4] + orderToChange.CreditCardNumber[length - 3] + orderToChange.CreditCardNumber[length - 2] + orderToChange.CreditCardNumber[length - 1];
                    }
                    orderToChange.ExpirationDate = order.ExpirationDate;
                    orderToChange.CardHolder = order.CardHolder;

                    db.Entry(orderToChange).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("CheckOut", new { id = orderToChange.OrderID });
                
              
            
        }

        
        [Authorize]
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
            if (User.IsInRole("Employee") || order.AppUser.Id == User.Identity.GetUserId())
            {

                return View(order);
            }
            else
            {
                return View("Error", new string[] { "This is not your order!!" });
            }
        }

        [HttpPost]
        public ActionResult CheckOut([Bind(Include = "OrderID, CheckOutStatus, PaymentMethod")] Order order, Confirm Confirm)
        {
            Order orderToChange = db.Orders.Find(order.OrderID);
            if (Confirm == Confirm.Yes)
            {
               
                orderToChange.PaymentMethod = PaymentMethod.CreditCard.ToString();
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

        [Authorize]
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
            if (User.IsInRole("Employee") || order.AppUser.Id == User.Identity.GetUserId())
            {

                return View(order);
            }
            else
            {
                return View("Error", new string[] { "This is not your order!!" });
            };
        }

        [HttpPost]
        public ActionResult Popcorn([Bind(Include = "OrderID, CheckOutStatus, PaymentMethod")] Order order, Confirm Confirm)
        {
            Order orderToChange = db.Orders.Find(order.OrderID);

            if (Confirm == Confirm.Yes)
            {
                orderToChange.CheckOutStatus = true;                
                orderToChange.PaymentMethod = PaymentMethod.PopcornPoints.ToString();
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

            String s = "Order Confirmation" + "\n" + "Confirmation Number:" + order.OrderNumber +"\n\n";
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
            if (User.IsInRole("Employee") || order.AppUser.Id == User.Identity.GetUserId())
            {

                return View(order);
            }
            else
            {
                return View("Error", new string[] { "This is not your order!!" });
            };
           
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
            if (User.IsInRole("Employee") || order.AppUser.Id == User.Identity.GetUserId())
            {

                return View(order);
            }
            else
            {
                return View("Error", new string[] { "This is not your order!!" });
            };
        }



        
        public ActionResult Gift(int? id)
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
            List<OrderDetail> ods = order.OrderDetails;
            foreach (OrderDetail od in ods)
            {
                if(od.SeatAssignment == null)
                {
                    ViewBag.Error = "You need to select seat.";
                    return View("Error");
                }
            }
            if (order.OrderDetails.Count() == 0)
            {
                ViewBag.Error = "You must choose what to purchase first";
                return View("Error");
            }

            //List<OrderDetail> ods = order.OrderDetails;
            for (int i = 0; i < ods.Count(); i++)
            {
                for (int j = i + 1; j < ods.Count(); j++)
                {
                    if (ods[i].Showing.Title == ods[j].Showing.Title)
                        if (ods[i].Showing.Date != ods[j].Showing.Date)
                        {
                            ViewBag.Error = "You need to create a separate transaction.";
                            return View("Error");
                        }
                }
            }

            List<OrderDetail> ods1 = order.OrderDetails.OrderBy(o => o.Showing.StartTime).ToList();

            foreach (OrderDetail od in ods1)
            {
                if (od.Showing.StartTime < DateTime.Now)
                {
                    ViewBag.Error = "You can't purchase a ticket that already started.";
                    return View("Error");
                }
            }

            for (int k = 0; k < ods1.Count(); k++)
            {
                for (int q = k + 1; q < ods1.Count(); q++)
                {
                    if (ods1[k].Showing.Title != ods1[q].Showing.Title)
                        if (ods1[k].Showing.EndTime > ods1[q].Showing.StartTime)
                        {
                            ViewBag.Error = "You can't purchase movies that overlap times.";
                            return View("Error");
                        }
                }
            }


            AppUser appuser = order.AppUser;
            if (appuser.Birthday.AddYears(18) > DateTime.Today)
            {
                foreach (OrderDetail od in ods1)
                {
                    if (od.Showing.Movie.MPAARating == enumMPAARating.NC17 || od.Showing.Movie.MPAARating == enumMPAARating.R)
                    {
                        ViewBag.Error = "You can't purchase NC17 or R.";
                        return View("Error");
                    }
                }
            }
            return View(order);
        }

        [HttpPost]
        public ActionResult Gift([Bind(Include = "OrderID, GiftOrNot")] Order order, Gift GiftOrNot)
        {
            Order orderGift = db.Orders.Find(order.OrderID);
            if (GiftOrNot.ToString() == "Yes")
            {
                orderGift.GiftOrNot = GiftOrNot.ToString();
                db.Entry(orderGift).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetEmail", new { id = orderGift.OrderID });
            }
            else
            {
                return RedirectToAction("CheckOutMethod", new { id = orderGift.OrderID });
            }
        }

        public ActionResult GetEmail(int? id)
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
        public ActionResult GetEmail([Bind(Include = "OrderID, Email")] Order order)
        {
            if (order.Email == null) {
                ViewBag.ErrorNoReceipent = "You need to enter email for receipent";
                return View(order);
            };
            Order orderGift = db.Orders.Find(order.OrderID);
            var query = from u in db.Users
                             select u;

            query = query.Where(a=>a.UserName.ToString() == order.Email);

            List<AppUser> appuser = query.ToList();
            if (appuser.Count == 0 )
            {
                ViewBag.ErrorNoReceipent = "No User Available";
                return View(order);

            }
            else
            {
                foreach (AppUser app in query)
                {
                    if (app.Birthday.AddYears(18) > DateTime.Today)
                    {
                        List<OrderDetail> ods1 = orderGift.OrderDetails;
                        foreach (OrderDetail od in ods1)
                        {
                            if (od.Showing.Movie.MPAARating == enumMPAARating.NC17 || od.Showing.Movie.MPAARating == enumMPAARating.R)
                            {
                                ViewBag.Error = "You can't purchase NC17 or R.";
                                return View("Error");
                            }
                        }
                    }
                    //app.Orders.Add(orderGift);
              
                    orderGift.FirstName = app.FirstName;
                    orderGift.LastName = app.LastName;
                    db.Entry(orderGift).State = EntityState.Modified;
                    
                   

                }

                db.SaveChanges();
                return RedirectToAction("CheckOutMethod", new { id = orderGift.OrderID });
            }
        }

        // GET: Orders/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Order order = db.Orders.Find(id);
        //    if (order == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    if (User.IsInRole("Employee") || order.AppUser.Id == User.Identity.GetUserId())
        //    {

        //        return View(order);
        //    }
        //    else
        //    {
        //        return View("Error", new string[] { "This is not your order!!" });
        //    };
        //}

        //// POST: Orders/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Order order = db.Orders.Find(id);
        //    db.Orders.Remove(order);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public SelectList GetAllCards(Order order)
        {
            String UserID = User.Identity.GetUserId();
            List<CreditCard> allCards = db.CreditCards.Where( c => c.AppUser.Id == UserID).ToList();

            //convert the list to a select list
            SelectList selCredits = new SelectList(allCards, "CreditCardID", "CreditCardNumberCardType");

            //return the select list
            return selCredits;
        }

        public static string GetDiscountTypes(OrderDetail od)
        {
            string discounttype;
            if (od.Showing.SpecialEvent == SpecialEvent.No)
            {
                if (od.Order.AppUser.Birthday.AddYears(60) < DateTime.Today && od.Order.OrderDetails.Count() < 2)
                {
                    discounttype = "Senior Discount";
                }
                else if ((od.Showing.Date.DayOfWeek.ToString() == "Monday" || od.Showing.Date.DayOfWeek.ToString() == "Wednesday" || od.Showing.Date.DayOfWeek.ToString() == "Thursday" || od.Showing.Date.DayOfWeek.ToString() == "Friday") && od.Showing.StartTime.Hour < 12)
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



        //method to get all products for the ViewBag
        public SelectList GetAllShowings()
        {

            var query = from s in db.Showings
                             select s;
            
            query = query.Where(s => s.Publish);
            query = query.Where(s => s.ShowingCancelStatus == ShowingCancelStatus.No);
            List<Showing> allShowings = query.OrderBy(c => c.Movie.Title).ToList();

            //convert the list to a select list
            SelectList selShowings = new SelectList(allShowings, "ShowingID", "MovieAndDate");

            //return the select list
            return selShowings;
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

        public ActionResult Cancellation(int? id)
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
            if (order.CancelStatus == CancelStatus.Yes)
            {
                ViewBag.NoCancelTwiceOrder = "This order has already been cancelled";
                return View("Error");
            }
            List<OrderDetail> ods = order.OrderDetails;
            foreach (OrderDetail od in ods)
            {
                if (DateTime.Today.AddHours(1) > od.Showing.StartTime)
                {
                    ViewBag.ErrorCancellation = "You can't cancel this order. Because at least one of your showing starts within an hour";
                    return View("Error");
                }
            }
            if (User.IsInRole("Employee") || order.AppUser.Id == User.Identity.GetUserId())
            {

                return View(order);
            }
            else
            {
                return View("Error", new string[] { "This is not your order!!" });
            };
        }

        [HttpPost]
        public ActionResult Cancellation([Bind(Include = "OrderID, CancelStatus")] Order order, Confirm Confirm)
        {       
            Order orderToChange = db.Orders.Find(order.OrderID);

            List<OrderDetail> ods = orderToChange.OrderDetails;
            foreach(OrderDetail od in ods)
            {
                if (DateTime.Today.AddHours(1) > od.Showing.StartTime)
                {
                    ViewBag.ErrorCancellation = "You can't cancel this order. Because at least one of your showing starts within an hour";
                    return View("Error");
                }
            }

            int numoforder = order.OrderDetails.Count();
            if (Confirm == Confirm.Yes && orderToChange.PaymentMethod == PaymentMethod.PopcornPoints.ToString())
            {
                orderToChange.CancelStatus = CancelStatus.Yes;
                String UserID = User.Identity.GetUserId();
                AppUser AppUser = db.Users.Find(UserID);
                Int32 popcornBalance = AppUser.PopcornPoints;                
                orderToChange.AppUser.PopcornPoints = orderToChange.AppUser.PopcornPoints + orderToChange.OrderDetails.Count() * 100;
                db.Entry(orderToChange).State = EntityState.Modified;
                db.SaveChanges();
                String emailSubject = "Cancellation";
                String emailBody = "Your order " + orderToChange.OrderNumber.ToString() + " is cancelled.";
                SendEmail(orderToChange.AppUser.Email, emailSubject, emailBody);
                return RedirectToAction("Index");
            }
            else if (Confirm == Confirm.Yes && orderToChange.PaymentMethod == PaymentMethod.CreditCard.ToString())
            {
                orderToChange.CancelStatus = CancelStatus.Yes;
                String UserID = User.Identity.GetUserId();
                AppUser AppUser = db.Users.Find(UserID);
                //Int32 popcornBalance = AppUser.PopcornPoints;
                //orderToChange.AppUser.PopcornPoints = orderToChange.AppUser.PopcornPoints + orderToChange.OrderDetails.Count() * 100;
                db.Entry(orderToChange).State = EntityState.Modified;
                db.SaveChanges();
                String emailSubject = "Cancellation";
                String emailBody = "Your order " + orderToChange.OrderNumber.ToString() + " is cancelled.";
                SendEmail(orderToChange.AppUser.Email, emailSubject, emailBody);
                return RedirectToAction("Index");
            }
            else
            {
                orderToChange.CancelStatus = CancelStatus.No;
                db.Entry(orderToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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
