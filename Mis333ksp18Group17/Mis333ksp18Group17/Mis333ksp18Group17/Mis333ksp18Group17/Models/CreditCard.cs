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
        [Required]
        [Display(Name = "Card Holder")]
        public String CardHolder { get; set; }

        [Required]
        [Display(Name = "Credit Card Number")]
        public String CreditCardNumber { get; set; }

        // public enum CardType { Visa, AmericanExpress, Discover, MasterCard }
        [Display(Name = "Card Type")]
        public string CardTypes
        {
            get { return GetCardTypes(CreditCardNumber); }
        }

        [Required]
        [Display(Name = "Expiration Date")]
        public DateTime ExpirationDate { get; set; }


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