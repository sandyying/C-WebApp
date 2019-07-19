using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;

//TODO: Change these using statements to match your project
using Mis333ksp18Group17.DAL;
using Mis333ksp18Group17.Models;
using System;

//TODO: Change this namespace to match your project
namespace Mis333ksp18Group17.Migrations
{
    //add identity data
    public class SeedIdentity
    {
        public void AddAdmin(AppDbContext db)
        {
            //create a user manager and a role manager to use for this method
            AppUserManager UserManager = new AppUserManager(new UserStore<AppUser>(db));

            //create a role manager
            AppRoleManager RoleManager = new AppRoleManager(new RoleStore<AppRole>(db));


            //check to see if the manager has been added
            AppUser manager = db.Users.FirstOrDefault(u => u.Email == "admin@example.com");

            //if manager hasn't been created, then add them
            if (manager == null)
            {
                //TODO: Add any additional fields for user here
                manager = new AppUser();
                manager.UserName = "admin@example.com";
                manager.FirstName = "Admin";
                manager.PhoneNumber = "(512)555-5555";
                manager.LastName = "Baker";

                manager.MiddleInitial = "L.";
                manager.Birthday = new System.DateTime(1949, 11, 23);
                manager.Street = "1245 Lake Anchorage Blvd.";
                manager.City = "Austin";
                manager.State = "TX";
                manager.ZipCode = "78705";
                manager.SSN = "9075571146";
                manager.PhoneNumber = "5125550180";

                manager.Email = "admin@example.com";

                var result = UserManager.Create(manager, "Abc123!");
                db.SaveChanges();
                manager = db.Users.First(u => u.UserName == "admin@example.com");


            }


            if (RoleManager.RoleExists("Manager") == false)
            {
                RoleManager.Create(new AppRole("Manager"));
            }

            if (RoleManager.RoleExists("Customer") == false)
            {
                RoleManager.Create(new AppRole("Customer"));
            }
            if (RoleManager.RoleExists("Employee") == false)
            {
                RoleManager.Create(new AppRole("Employee"));
            }
            if (UserManager.IsInRole(manager.Id, "Manager") == false)
            {
                UserManager.AddToRole(manager.Id, "Manager");
            }

        }
    }
          

    }
    