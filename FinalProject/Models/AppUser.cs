using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace FinalProject.Models
{
    public class AppUser : IdentityUser
    {
        [Display(Name = "User ID")]
        public Int32 UserID { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        public String FullName
        {
            get { return FirstName + " " + LastName; }
        }

        [Required(ErrorMessage = "Street address is required.")]
        [Display(Name = "Street Address")]
        public String StreetAddress { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [Display(Name = "City")]
        public String City { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [Display(Name = "State")]
        public String State { get; set; }

        [Required(ErrorMessage = "Zipcode is required.")]
        [Display(Name = "Zipcode")]
        public Int32 ZipCode { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [Display(Name = "Password")]
        public String Password { get; set; }

        public List<CreditCard> CreditCards { get; set; }

        //add a property that makes it display as only its last 4 digits w/ 12 X's in front
        [Required(ErrorMessage = "Credit Card Number is required.")]
        [StringLength(16, ErrorMessage = "Credit card are 16 digits.", MinimumLength = 16)]
        [Display(Name = "Credit Card Number")]
        public String CreditCardNumber { get; set; }

        [Required(ErrorMessage = "Credit Card Type is required.")]
        [Display(Name = "Credit Card Type")]
        public String CreditCardType { get; set; }

        public List<Cart> Carts { get; set; }

        //public List<Review> Reviews { get; set; }

        public Int32 TotalBooksPurchased { get; set; }

        public Boolean Active { get; set; }

        public Int32 NumOfReviewsApp { get; set; }

        public Int32 NumOfReviewsRej { get; set; }

        [Display(Name = "Profit Margin")]
        public Decimal ProfitMargin { get; set; }

        [Display(Name = "Amount of Revenue")]
        public Decimal AmountOfRevenue { get; set; }

        [Display(Name = "Average Weighted Cost")]
        public Decimal AvgWeightedCost { get; set; }

        [InverseProperty("Author")]
        public List<Review> ReviewsWritten { get; set; }

        [InverseProperty("Approver")]
        public List<Review> ReviewsApproved { get; set; }

        public AppUser()
        {
            if (Carts == null)
            {
                Carts = new List<Cart>();
            }

            //if (Reviews == null)
            //{
            //    Reviews = new List<Review>();
            //}

            if (CreditCards == null)
            {
                CreditCards = new List<CreditCard>();
            }
        }
    }
}