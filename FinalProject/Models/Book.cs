using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Book
    {
        [Display(Name = "Book ID")]
        public Int32 BookID { get; set; }

        [Required(ErrorMessage = "Published date is required.")]
        [Display(Name = "Published Date")]
        public DateTime PublishedDate { get; set; }

        [Display(Name = "Unique ID")]
        public Int32 UniqueID { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [Display(Name = "Title")]
        public String Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [Display(Name = "Description")]
        public String Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Price { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        [Display(Name = "Author")]
        public String Author { get; set; }

        [Required(ErrorMessage = "Cost is required.")]
        [Display(Name = "Cost")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Cost { get; set; }

        public Int32 Reorder { get; set; }

        [Display(Name = "Copies on hand")]
        public Int32 CopiesOnHand { get; set; }

        [Display(Name ="Last Ordered")]
        public DateTime LastOrdered { get; set; }

        //public Decimal TotalRevenue { get; set; }

        //public Decimal TotalCost { get; set; }

        [Display(Name = "Avg Weighted Price")]
        public Decimal AvgWeightedPrice { get; set; }

        [Display(Name = "Avg Weighted Cost")]
        public Decimal AvgWeightedCost { get; set; }

        public Decimal ProfitMargin { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Average Rating")]
        [DisplayFormat(DataFormatString = "{0:#.#}")]
        public Decimal AvgRating
        {
            //get { return Reviews.Average(r => r.Rating); }
            get;
            set;
        }

        public Int32 CopiesSold { get; set; }

        public Boolean AutoReorder {get; set;}

        [System.ComponentModel.DefaultValue(5)]
        public Int32 AutoReorderQuantity {get; set;}

        public Decimal AutoReorderPrice {get; set;}

        public List<Review> Reviews { get; set; }

        public List<BookProcurement> BookProcurements { get; set; }

        public List<CartDetail> CartDetails { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public Boolean Active { get; set; }

        public Book()
        {
            if (Reviews == null)
            {
                Reviews = new List<Review>();
            }

            if (CartDetails == null)
            {
                CartDetails = new List<CartDetail>();
            }

        }
    }
}
