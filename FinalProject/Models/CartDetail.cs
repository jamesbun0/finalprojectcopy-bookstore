using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class CartDetail
    {
        [Display(Name = "Cart Detail ID")]
        public Int32 CartDetailID { get; set; }

        [Display(Name = "Title")]
        public String Title { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Price")]
        public Decimal Price { get; set; }

        [Range(1, 1000, ErrorMessage = "Quantity must be between 1 and 1000")]
        [Display(Name ="Quantity")]
        public Int32 Quantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Extended Price")]
        public Decimal ExtendedPrice { get; set; }

        public Decimal TotalCost { get; set; }

        public String CustomerName { get; set; }

        public Cart Cart { get; set; }

        public Book Book { get; set; }

    }
}
