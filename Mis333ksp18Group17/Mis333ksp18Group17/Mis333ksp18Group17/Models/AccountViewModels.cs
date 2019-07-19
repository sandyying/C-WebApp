using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

//TODO: Change this namespace to match your project
namespace Mis333ksp18Group17.Models
{
   
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {

        //TODO:  Add any fields that you need for creating a new user
        //Additional fields go here (First name is an example)
        //Remember, there is already a field for email, phone number, and password
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

       // [Required(ErrorMessage = "Please enter the SSN")]
        [Display(Name = "SSN")]
        public String SSN { get; set; }

        [Display(Name = "PopcornPoints")]
        public Int32 PopcornPoints { get; set; }

      
        [Display(Name = "Employee Type")]
        [EnumDataType(typeof(Type))]
        public Type Type { get; set; }




        //NOTE: Here is the property for email
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //NOTE: Here is the property for phone number
        [Required(ErrorMessage = "Phone number is required")]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        //NOTE: Here is the logic for putting in a password
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }   

    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public String UserName { get; set; }
        public String Email { get; set; }
        public String UserID { get; set; }
    }
}
