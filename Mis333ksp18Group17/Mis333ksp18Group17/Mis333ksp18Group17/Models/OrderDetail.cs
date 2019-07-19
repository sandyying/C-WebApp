using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Mis333ksp18Group17.Models
{
    public class OrderDetail
    {
        public enum DayWeek { Monday, Tuesday, Wendesday, Thursday, Friday, Saturday, Sunday }
        [Key]
        public Int32 OrderDetailID { get; set; }

        public String SeatAssignment { get; set; }

        public virtual Order Order { get; set; }

        public virtual Showing Showing { get; set; }

        [Display(Name = "Type of Discount")]
        public String DiscountType { get; set; }

        [Required(ErrorMessage = "You need to enter the number for ticket")]
        [Display(Name = "Quantity")]
        [Range(1, 1, ErrorMessage = "You can only add one ticket per time")]
        public Int32 Quantity { get; set; }

        [Required(ErrorMessage = "Please enter the price of the item at the time of order")]
        [Display(Name = "Product Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal MoviePrice { get; set; }

        [Required(ErrorMessage = "Please enter the quantity* product price at the time of the order")]
        [Display(Name = "Total Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal TotalPrice { get; set; }
    }
}