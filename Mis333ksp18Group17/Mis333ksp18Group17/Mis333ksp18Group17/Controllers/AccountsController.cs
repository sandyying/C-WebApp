﻿using System;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Mis333ksp18Group17.DAL;
using System.Collections.Generic;
using System.Net;

//Change this using statement to match your project
using Mis333ksp18Group17.Models;

//Change this namespace to match your project
namespace Mis333ksp18Group17.Controllers
{
    [Authorize]
    public class AccountsController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private AppUserManager _userManager;
        private AppDbContext db = new AppDbContext();

        public AccountsController()
        {
        }

        //NOTE: This creates a user manager and a sign-in manager every time someone creates a request to this controller
        public AccountsController(AppUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public AppUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // NOTE:  This is the logic for the login page
        // GET: /Accounts/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (HttpContext.User.Identity.IsAuthenticated) //user has been redirected here from a page they're not authorized to see
            {
                return View("Error", new string[] { "Access Denied" });
            }
            AuthenticationManager.SignOut(); //this removes any old cookies hanging around
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Accounts/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            String UserId = User.Identity.GetUserId();
            AppUser appuser = db.Users.Find(UserId);
            if (User.IsInRole("Fire"))
            {

            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    int hour = DateTime.Now.Hour;
                    ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
                    return View("MyView");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }


        //
        // GET: /Accounts/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        // NOTE: Here is your logic for registering a new user
        // POST: /Accounts/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (model.Type ==Type.Null && model.Birthday.AddYears(13) > DateTime.Today)
            {
                ViewBag.ErrorM = "You need to at least 13 years old to register";
                return View("AccountError");
            }
            if (model.Type == Type.Employee && model.Birthday.AddYears(18) > DateTime.Today)
            {
                ViewBag.ErrorM = "You need to at least 18 years old to register";
                return View("AccountError");
            }

            if (ModelState.IsValid)
            {
                //TODO: Add fields to user here so they will be saved to do the database
                var user = new AppUser
                {
                    Number = Utilities.GenerateCustomerNumber.GetNextCustomerNumber(),
                    
                    UserName = model.Email,
                    Email = model.Email,
                    //Firstname is an example - you will need to add the rest
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MiddleInitial = model.MiddleInitial,
                    Birthday = model.Birthday,
                    Street = model.Street,
                    City = model.City,
                    State = model.State,
                    ZipCode = model.ZipCode,
                    SSN = model.SSN,
                    PhoneNumber = model.PhoneNumber,
                    PopcornPoints = model.PopcornPoints
                };
                var result = await UserManager.CreateAsync(user, model.Password);

                //TODO:  Once you get roles working, you may want to add users to roles upon creation
                await UserManager.AddToRoleAsync(user.Id, "Customer");
                // --OR--
                // await UserManager.AddToRoleAsync(user.Id, "Employee");


                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                    
                    
                    SendEmail(model.Email, "Register Confirmation", "Thanks for Registering with us.");
                    
                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
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
            String finalMessage = emailBody + "\n\n Team 17";
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
        //GET: Accounts/Index
        public ActionResult Index()
        {
            IndexViewModel ivm = new IndexViewModel();

            //get user info
            String id = User.Identity.GetUserId();
            AppUser user = db.Users.Find(id);

            //populate the view model
            ivm.Email = user.Email;
            ivm.HasPassword = true;
            ivm.UserID = user.Id;
            ivm.UserName = user.UserName;


            return View(ivm);
        }



        //Logic for change password
        // GET: /Accounts/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Accounts/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", "Home");
            }
            AddErrors(result);
            return View(model);
        }

       

        // POST: /Accounts/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region 

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}