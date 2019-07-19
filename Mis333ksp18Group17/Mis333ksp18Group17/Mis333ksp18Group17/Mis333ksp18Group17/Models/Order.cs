using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Mis333ksp18Group17.Models
{
    public class Order
    {
        //public enum DayWeek { Monday, Tuesday, Wendesday, Thursday, Friday, Saturday, Sunday}
        [Key]
        public Int32 OrderID { get; set; }

       
        [Display(Name = "Order #:")]
        public Int32 OrderNumber { get; set; }

        [Display(Name = "Movie Price:")]
        public Decimal MoviePrice { get; set; }

        [Display(Name = "Order Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyy}")]
        public DateTime? OrderDate { get; set; }

        // public DayWeek DayOfWeek { get; set; }

        //[DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.DateTime)]
        //public DateTime? StartTime { get; set; }
      
        [Display(Name = "Subtotal:")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Subtotal 
        {
            get { return OrderDetails.Sum(rd => rd.TotalPrice); }
        }      


        [Display(Name = "Discount:")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal DiscountAmt { get; set; }

 
        [Display(Name = "Tax:")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        const Decimal decTax = 0.0825m;


        [Display(Name = "Total Before Tax:")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal TotalBeforeTax 
        {
            get { return (Subtotal-DiscountAmt) ; }
        }

        [Display(Name = "Sales Tax:")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal SalesTax
        {
            get { return TotalBeforeTax * decTax; }
        }

        [Display(Name = "Total:")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal TotalPrice
        {
            get { return TotalBeforeTax  + SalesTax; }
        }

        [Display(Name = "Order Notes")]
        public String Notes { get; set; }



        //// checkout page 
        //[Display(Name = "Receipent")]
        //public String Receipent { get; set; }




        //[Display(Name = "Payment Method")]
        //public String PaymentMethod { get; set; }

        [Display(Name = "Credit Card Number")]
        public String CreditCardNumber { get; set; }

        [Display(Name = "Card Type")]
        public String CardType {            
                get { return GetCardTypes(CreditCardNumber); }
            
        }

        [Display(Name = "Expiration Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM}", ApplyFormatInEditMode = true)]
        public DateTime? ExpirationDate { get; set; }

        [Display(Name = "Card Holder")]
        public String CardHolder { get; set; }

        [Display(Name = "Check Out Status")]
        public bool CheckOutStatus { get; set; }

        public static string GetCardTypes(string creditcardnumber)
        {
            Int32 CardLength = creditcardnumber.Length;
            string cardtype;

            if (CardLength == 15)
            {
                cardtype = "American Express";
            }
            else
            {
                if (creditcardnumber[0] == 4)
                {
                    cardtype = "Visa";
                }
                if (creditcardnumber[0] == 6)
                {
                    cardtype = "Discover";
                }
                else
                {
                    cardtype = "MasterCard";
                }
            }

            return cardtype;
        }

        public virtual List<OrderDetail> OrderDetails { get; set; }
    
             
        public virtual AppUser AppUser { get; set; }
       
        public Order()
        {
            if (OrderDetails == null)
            {
                OrderDetails = new List<OrderDetail>();
            }
        }
    }
}