using System.Linq;
using Mis333ksp18Group17.DAL;
using Mis333ksp18Group17.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Mis333ksp18Group17.Migrations
{
    public class AddEmployees
    {
        //public static AppDbContext db = new AppDbContext();

        public void SeedEmployees(AppDbContext db)
        {
            //create a user manager and a role manager to use for this method
            AppUserManager UserManager = new AppUserManager(new UserStore<AppUser>(db));

            AppUser c0 = new AppUser();
            c0.Number = 5001;
            c0.LastName = "Baker";
            c0.FirstName = "Christopher";
            c0.MiddleInitial = "L.";
            c0.Birthday = new System.DateTime(1949, 11, 23);
            c0.Street = "1245 Lake Anchorage Blvd.";
            c0.City = "Austin";
            c0.State = "TX";
            c0.ZipCode = "78705";
            c0.SSN = "9075571146";
            c0.PhoneNumber = "5125550180";
            c0.PopcornPoints = 110;
            c0.Email = "cbaker@example.com";
            c0.UserName = "cbaker@example.com";


            var result0 = UserManager.Create(c0, "hello1");
            db.SaveChanges();
            c0 = db.Users.FirstOrDefault(u => u.UserName == "cbaker@example.com");
            if (UserManager.IsInRole(c0.Id, "Employee") == false)
            {
                UserManager.AddToRole(c0.Id, "Employee");
            }


           
        }
    }
}