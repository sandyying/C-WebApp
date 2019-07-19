using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
public enum Approve { No, Yes}

namespace Mis333ksp18Group17.Models
{
    public enum vote { Upvote, Downvote }
    

    public class Review
    {
        public Int32 ReviewID { get; set; }

        //[Required]
        //[Display(Name = "Movie Title")]        
        //public String MovieTitle { get; set; }

        [Display(Name = "Reviews")]
        [StringLength(100)]
        public String Reviews { get; set; }

         
        [Display(Name = "Approve?")]
        //[Range(typeof(Int32), "1", "5")]
        public Approve Approve { get; set; }

        [Required]
        [Display(Name = "Customer Rating")]
        //[Range(typeof(Int32), "1", "5")]
        public Int32 CustomerRating { get; set; }

        [Display(Name = "Number of Up Votes")]
        public Int32? UpVote { get; set; }

        [Display(Name = "Number of Down Votes")]
        public Int32? DownVote { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual AppUser appuser { get; set; }
    }
}