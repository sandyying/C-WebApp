using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


public enum Type { Employee, Manager }
namespace Mis333ksp18Group17.Models
{
    public class User
    {
        [Key]
        [Display(Name = "User ID")]
        public Int32 UserID { get; set; }

        [Required(ErrorMessage = "Please enter the password")]
        [Display(Name = "Password")]
        public String Password { get; set; }

        [Required(ErrorMessage = "Please enter the last name")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Required(ErrorMessage="Please enter the first name")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

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
        public Int32 ZipCode { get; set; }

        [Required(ErrorMessage = "Please enter the SSN")]
        [Display(Name = "SSN")]
        public Int32 SSN { get; set; }

        [Required(ErrorMessage = "Please enter the email address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Enter a valid email address")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter the PopcornPoints")]
        [Display(Name = "PopcornPoints")]
        public Int32 PopcornPoints { get; set; }

        [Required]
        [Display(Name = "Employee Type")]
        [EnumDataType(typeof(Type))]
        public Type Type { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [DisplayFormat(DataFormatString = "{0:###-###-####}", ApplyFormatInEditMode = true)]
        public string PhoneNumber { get; set; }

    }
}