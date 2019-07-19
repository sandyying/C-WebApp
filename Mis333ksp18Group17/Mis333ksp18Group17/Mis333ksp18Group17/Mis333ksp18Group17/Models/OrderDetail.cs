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

        public virtual List<Seat> Seats { get; set; }
        public OrderDetail()
        {
            if (Seats == null)
            {
                Seats = new List<Seat>();
            }
        }
       // public DayWeek DayOfWeek { get; set; }
        
        [Required(ErrorMessage = "Please enter the quantity")]
        [Display(Name = "Quantity")]
        [Range(1, 32, ErrorMessage = "Ticket quantity can only be 1 to 32")]
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