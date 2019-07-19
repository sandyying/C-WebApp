using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

public enum Type {Null, Employee, Manager}
//TODO: Change this namespace to match your project
namespace Mis333ksp18Group17.Models
{
   
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    //NOTE: This is the class for users
    public class AppUser : IdentityUser
    {
        //TODO: Put any additional fields that you need for your user here
        //First name is here as an example
        [Display(Name = "Customer Number")]
        public Int32 Number { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Please enter the last name")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }


        [Display(Name = "Middle Initial")]
        public String MiddleInitial { get; set; }

        [Required(ErrorMessage = "Please enter the birthday")]
        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Please enter the street name")]
        [Display(Name = "Street")]
        public String Street { get; set; }

        [Required(ErrorMessage = "Please enter the city name")]
        [Display(Name = "City")]
        public String City { get; set; }

        [Required(ErrorMessage = "Please enter the state")]
        [Display(Name = "State")]
        public String State { get; set; }

        [Required(ErrorMessage = "Please enter the zip code")]
        [Display(Name = "Zip Code")]
        public String ZipCode { get; set; }

        //[Required(ErrorMessage = "Please enter the SSN")]
        [Display(Name = "SSN")]
        public String SSN { get; set; }

        [Display(Name = "PopcornPoints")]
        public Int32 PopcornPoints { get; set; }

        [Display(Name = "Employee Type")]
        [EnumDataType(typeof(Type))]
        public Type Type { get; set; }

        
        public virtual List<CreditCard> CreditCards { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<Review> Reviews { get; set; }

        public AppUser()
        {
            if (CreditCards == null)
            {
                CreditCards = new List<CreditCard>();
            }


            if (Orders == null)
            {
                Orders = new List<Order>();
            }
            if(Reviews == null)
            {
                Reviews = new List<Review>();
            }

        }
        //TODO: Add any navigational properties needed for your user
        //Orders is here as an example
        //public virtual List<Order> Orders { get; set; }


        //This method allows you to create a new user
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser> manager)
        {
            // NOTE: The authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}