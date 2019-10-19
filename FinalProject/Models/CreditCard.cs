using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class CreditCard
    {
        public Int32 CreditCardID { get; set; }

        //add a property that makes it display as only its last 4 digits w/ 12 X's in front
        [Required(ErrorMessage = "Credit Card Number is required.")]
        [StringLength(16, ErrorMessage = "Credit card are 16 digits.", MinimumLength = 16)]
        [Display(Name = "Credit Card Number")]
        public String CreditCardNumber { get; set; }

        [Required(ErrorMessage = "Credit Card Type is required.")]
        [Display(Name = "Credit Card Type")]
        public String CreditCardType { get; set; }

        public AppUser Customer { get; set; }

        public List<Cart> Carts { get; set; }

        public CreditCard()
        {
            if (Carts == null)
            {
                Carts = new List<Cart>();
            }
        }
    }
}
