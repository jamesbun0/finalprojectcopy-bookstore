using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Review
    {
        [Display(Name = "Review ID")]
        public Int32 ReviewID { get; set; }

        [Range(1,5,ErrorMessage ="Rating must be 1-5")]
        [DisplayFormat(DataFormatString ="{0:#.#}")]
        public Decimal Rating { get; set; }

        [StringLength(100, ErrorMessage = "Reviews must be at least one character", MinimumLength = 1)]
        [Display(Name = "Reviews Written")]
        public String ReviewsWritten { get; set; }

        [Display(Name = "Reviews Approved")]
        public Boolean ReviewsApproved { get; set; }

        public AppUser Author { get; set; }

        public AppUser Approver { get; set; }

        public Book Book { get; set; }

        //make sure to take this out
        public AppUser Customer { get; set; }

    }
}
