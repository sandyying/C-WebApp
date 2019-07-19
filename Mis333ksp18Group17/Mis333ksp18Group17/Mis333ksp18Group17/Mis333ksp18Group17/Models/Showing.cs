using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Mis333ksp18Group17.Models
{
    public enum Location { Theatre1, Theatre2} 
    public enum Pending { Yes, No }
    public enum SpecialEvent { Yes, No}
    public class Showing
    {
        [Key]
        public Int32 ShowingID { get; set; }

        public Location Location { get; set; }

        public String Title { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Showing Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public String MovieAndDate
        {
            get
            {
                return  Title + " " + Date.ToString();
            }
        }
        //[DataType(DataType.Date)]
        //[Display(Name = "Start Date")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime StartDate {
        //    get
        //    {
        //        return Date.AddDays(0);
        //    }
        //}

        //[DataType(DataType.Date)]
        //[Display(Name = "End Date")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime EndDate { get {
        //        return Date.AddDays(7);
        //            } }

        [DisplayFormat(DataFormatString = "{0:HH:mm}",ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]       
        public DateTime StartTime
        {
            get
            {
                return Date.AddMinutes(0);
            }
        }

        [Display(Name = "Runtime")]
        public Int32 Runtime { get; set; }

        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]       
        public DateTime EndTime{
         get {
                return Date.AddMinutes(Runtime);  }
            }

        
        //public DayOfWeek DayOfWeek
        //{
        //    get
        //    {
        //        return Date.DayOfWeek;
        //    }
        //} 
        [Required]
        public Pending Pending { get; set; }

        [Required]
        public SpecialEvent SpecialEvent { get; set; }

        //[Display(Name = "Movie Price")]
        //[DisplayFormat(DataFormatString = "{0:C}")]
        //public Decimal MoviePrice { get; set; }

        public virtual List<OrderDetail> OrderDetails{ get; set; }

        public virtual Movie Movie { get; set; }

        public Showing()
        {
            if (OrderDetails == null)
            {
                OrderDetails = new List<OrderDetail>();
            }
        }

    }
}