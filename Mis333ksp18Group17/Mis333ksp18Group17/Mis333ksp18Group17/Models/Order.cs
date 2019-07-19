using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
public enum  CancelStatus {No, Yes}
namespace Mis333ksp18Group17.Models
{
    public class Order
    {
        
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

        [Display(Name = "Gift Or Not")]
        public String GiftOrNot { get; set; }

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




        [Display(Name = "Payment Method")]
        public String PaymentMethod { get; set; }

        [Display(Name = "Credit Card Number")]
        public String CreditCardNumber { get; set; }

        [Display(Name = "Card Type")]
        public String CardType { get ; set; }

        [Display(Name = "Expiration Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM}", ApplyFormatInEditMode = true)]
        public DateTime? ExpirationDate { get; set; }

        [Display(Name = "Card Holder")]
        public String CardHolder { get; set; }

        [Display(Name = "Check Out Status")]
        public bool CheckOutStatus { get; set; }


        [Display(Name = "Email Receipent")]
        public String Email { get; set; }

        [Display(Name = "Receipent First Name")]
        public String FirstName  { get; set; }

        [Display(Name = "Receipent Last Name")]
        public String LastName { get; set; }
        //[Display(Name = "Confirmation Number")]
        //public Int32 ConfirmationNumber { get; set; }
        //public static string GetCardTypes(string creditcardnumber)
        //{
        //    Int32 CardLength = creditcardnumber.Length;
        //    string cardtype;

        //    if (CardLength == 15)
        //    {
        //        cardtype = "American Express";
        //    }
        //    else
        //    {
        //        if (creditcardnumber[0] == 4)
        //        {
        //            cardtype = "Visa";
        //        }
        //        if (creditcardnumber[0] == 6)
        //        {
        //            cardtype = "Discover";
        //        }
        //        else
        //        {
        //            cardtype = "MasterCard";
        //        }
        //    }

        //    return cardtype;
        //}
        [Display(Name = "Cancel?")]
        public CancelStatus CancelStatus { get; set; }


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