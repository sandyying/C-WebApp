using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mis333ksp18Group17.Models
{
    public class CreditCard
    {

        public Int32 CreditCardID { get; set; }
        [Required(ErrorMessage = "Card holder is required")]
        [Display(Name = "Card Holder")]
        public String CardHolder { get; set; }

        [Required(ErrorMessage = "Please enter a valid credit card number")]
        //[StringLength(16, MinimumLength = 15, ErrorMessage = "Invalid Credit Card Number")]
        //[MaxLength(16), MinLength(15)]
        [Display(Name = "Credit Card Number")]
        public String CreditCardNumber { get; set; }

        // public enum CardType { Visa, AmericanExpress, Discover, MasterCard }
        [Display(Name = "Card Type")]
        public string CardTypes { get;set; }
        
      //  public String CreditCardlas

        [Required(ErrorMessage = "Expiration Date is required")]
        [Display(Name = "Expiration Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM}", ApplyFormatInEditMode = true)]
        public DateTime ExpirationDate { get; set; }

        [Display(Name = "Credit Card Number")]
        public String CreditCardNumberCardType{ get
            {
                return CreditCardNumber + " " + CardTypes;
            }
        }

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

        // navigational property 
        // public virtual AppUser AppUser { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }

   
        public virtual AppUser AppUser { get; set; }
      
        public CreditCard()
        {
            if (OrderDetails == null)
            {
                OrderDetails = new List<OrderDetail>();
            }
        }



    }
}