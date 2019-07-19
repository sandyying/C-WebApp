using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Mis333ksp18Group17.Models
{
   
        public class Seat
        {
            [Key]
            public Int32 SeatID { get; set; }
            public String SeatName { get; set; }

            public virtual OrderDetail OrderDetail { get; set; }
        }

    
}