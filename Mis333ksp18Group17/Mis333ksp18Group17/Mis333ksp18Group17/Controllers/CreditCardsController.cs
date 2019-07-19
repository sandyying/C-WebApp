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
    public class CreditCardsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: CreditCards

        public ActionResult Index()
        {

            if (User.IsInRole("Manager"))
            {
                return View(db.CreditCards.ToList());
            }
            else
            {
                String UserId = User.Identity.GetUserId();
                List<CreditCard> cds = db.CreditCards.Where(c => c.AppUser.Id == UserId).ToList();
                return View(cds);
            }
           
        }

        // GET: CreditCards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCard creditCard = db.CreditCards.Find(id);
            if (creditCard == null)
            {
                return HttpNotFound();
            }
            if (User.IsInRole("Employee") || creditCard.AppUser.Id == User.Identity.GetUserId())
            {
                return View(creditCard);
            }

            else
            {
                return View("Error", new string[] { "This is not your profile" });
            }
            
        }

        [Authorize]
        public ActionResult Create()
        {
            String UserID = User.Identity.GetUserId();
            AppUser AppUser = db.Users.Find(UserID);
            List<CreditCard> cds = AppUser.CreditCards;
            if (cds.Count() < 2)
            {
                return View();
            }
            ViewBag.Error = "You can't have more than two credit cards.";
            return View("CDError");

        }

        // POST: CreditCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CreditCardID,CardHolder,CreditCardNumber,ExpirationDate, CardTypes")] CreditCard creditCard)
        {
                if(creditCard.CreditCardNumber != null)
                {
                    foreach (char c in creditCard.CreditCardNumber)
                    {
                        if (c < '0' || c > '9')
                        {
                            ViewBag.Error = "Please enter all digits";
                            return View(creditCard);
                        }
                    }

                    if (creditCard.CreditCardNumber.Length != 15 & creditCard.CreditCardNumber.Length != 16)
                    {
                        ViewBag.Error = "Please enter 15 or 16 digits card number";
                        return View(creditCard);
                    }
                    else
                    {
                        if (creditCard.CreditCardNumber.Length == 16)
                        {
                            if (creditCard.CreditCardNumber[0] != '4' & creditCard.CreditCardNumber[0] != '6' & (creditCard.CreditCardNumber[0] != '5' && creditCard.CreditCardNumber[1] != '4'))
                            {
                                ViewBag.Error = "Invalid Credit Card";
                                return View(creditCard);
                            }
                            else
                            {
                                if (creditCard.CreditCardNumber[0] == '4')
                                {
                                    creditCard.CardTypes = "Visa";
                                }
                                else if (creditCard.CreditCardNumber[0] == '6')
                                {
                                    creditCard.CardTypes = "Discover";
                                }
                                else
                                {
                                    creditCard.CardTypes = "MasterCard";
                                }
                            }
                        }
                        else
                        {                            
                                creditCard.CardTypes = "American Express";                    
                        }
                }

                    if (creditCard.CreditCardNumber.Length == 16)
                    {
                        Int32 length = creditCard.CreditCardNumber.Length;
                        creditCard.CreditCardNumber = "************" + creditCard.CreditCardNumber[length - 4] + creditCard.CreditCardNumber[length - 3] + creditCard.CreditCardNumber[length - 2] + creditCard.CreditCardNumber[length - 1];
                    }

                    if (creditCard.CreditCardNumber.Length == 15)
                    {
                        Int32 length = creditCard.CreditCardNumber.Length;
                        creditCard.CreditCardNumber = "***********" + creditCard.CreditCardNumber[length - 4] + creditCard.CreditCardNumber[length - 3] + creditCard.CreditCardNumber[length - 2] + creditCard.CreditCardNumber[length - 1];
                    }


                }
                
            




            if (ModelState.IsValid)
                {
                                         
                    creditCard.AppUser = db.Users.Find(User.Identity.GetUserId());
                    db.CreditCards.Add(creditCard);
                    db.SaveChanges();
                    

                    return RedirectToAction("Index");
                }
            

            return View(creditCard);
         }

        // GET: CreditCards/Edit/5


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCard creditCard = db.CreditCards.Find(id);
            if (creditCard == null)
            {
                return HttpNotFound();
            }
            if (User.IsInRole("Employee") || creditCard.AppUser.Id == User.Identity.GetUserId())
            {
                return View(creditCard);
            }

            else
            {
                return View("Error", new string[] { "This is not your profile" });
            }
           
        }

        // POST: CreditCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CreditCardID,CardHolder,CreditCardNumber,ExpirationDate")] CreditCard creditCard)
        {

            CreditCard cd = db.CreditCards.Find(creditCard.CreditCardID);

            if (creditCard.CreditCardNumber != null)
            {
                foreach (char c in creditCard.CreditCardNumber)
                {
                    if (c < '0' || c > '9')
                    {
                        ViewBag.Error = "Please enter all digits";
                        return View(cd);
                    }
                }

                if (creditCard.CreditCardNumber.Length != 15 & creditCard.CreditCardNumber.Length != 16)
                {
                    ViewBag.Error = "Please enter 15 or 16 digits card number";
                    return View(creditCard);
                }
                else
                {
                    if (creditCard.CreditCardNumber[0] != '4' & creditCard.CreditCardNumber[0] != '6' & (creditCard.CreditCardNumber[0] != '5' && creditCard.CreditCardNumber[1] != '4'))
                    {

                        ViewBag.Error = "Invalid Credit Card";
                        return View(creditCard);
                    }
                    else
                    {

                        if (creditCard.CreditCardNumber.Length == 15)
                        {
                            creditCard.CardTypes = "American Express";

                        }
                        else
                        {
                            if (creditCard.CreditCardNumber[0] == '4')
                            {
                                creditCard.CardTypes = "Visa";

                            }
                            else if (creditCard.CreditCardNumber[0] == '6')
                            {
                                creditCard.CardTypes = "Discover";

                            }
                            else
                            {
                                creditCard.CardTypes = "MasterCard";

                            }
                        }
                    }
                }

                if (creditCard.CreditCardNumber.Length == 16)
                {
                    Int32 length = creditCard.CreditCardNumber.Length;
                    creditCard.CreditCardNumber = "************" + creditCard.CreditCardNumber[length - 4] + creditCard.CreditCardNumber[length - 3] + creditCard.CreditCardNumber[length - 2] + creditCard.CreditCardNumber[length - 1];
                }

                if (creditCard.CreditCardNumber.Length == 15)
                {
                    Int32 length = creditCard.CreditCardNumber.Length;
                    creditCard.CreditCardNumber = "***********" + creditCard.CreditCardNumber[length - 4] + creditCard.CreditCardNumber[length - 3] + creditCard.CreditCardNumber[length - 2] + creditCard.CreditCardNumber[length - 1];
                }


            }

            if (ModelState.IsValid)
                {

                    cd.CreditCardNumber = creditCard.CreditCardNumber;
                    cd.CardTypes = creditCard.CardTypes;
                    cd.CardHolder = creditCard.CardHolder;
                    cd.ExpirationDate = creditCard.ExpirationDate;
                
                    db.Entry(cd).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            
            return View(creditCard);
        }


        // GET: CreditCards/Delete/5
       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCard creditCard = db.CreditCards.Find(id);
            if (creditCard == null)
            {
                return HttpNotFound();
            }
            if (User.IsInRole("Employee") || creditCard.AppUser.Id == User.Identity.GetUserId())
            {
                return View(creditCard);
            }

            else
            {
                return View("Error", new string[] { "This is not your profile" });
            }
          
        }

        // POST: CreditCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CreditCard creditCard = db.CreditCards.Find(id);
            db.CreditCards.Remove(creditCard);
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
