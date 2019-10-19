using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Cart
    {
        public const Decimal TAX = .0825m;

        [Display(Name ="Order ID")]
        public Int32 CartID { get; set; }

        public Int32 CartNumber { get; set; }

        [Display(Name = "Order Date")]
        public DateTime CartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Subtotal")]
        public Decimal CartSubtotal
        {
            get { return CartDetails.Sum(r => r.ExtendedPrice); }
        }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Total")]
        public Decimal CartTotal
        {
            get { return CartSubtotal + Tax; }
        }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Shipping")]
        public Decimal Shipping { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Tax")]
        public Decimal Tax { get { return CartSubtotal * TAX; } }

        [Display(Name ="Status")]
        public Boolean Status { get; set; }

        [Display(Name = "Avg Weighted Price")]
        public Decimal AvgWeightedPrice { get; set; }

        [Display(Name = "Avg Weighted Cost")]
        public Decimal AvgWeightedCost { get; set; }

        public Decimal ProfitMargin { get; set; }

        public Int32 TotalQuantity { get; set; }

        public String CustomerName { get; set; }

        public AppUser Customer { get; set; }

        [Display(Name ="Coupon")]
        public Coupon Coupon { get; set; }

        [Display(Name ="Credit Card")]
        public CreditCard CreditCard { get; set; }

        public List<CartDetail> CartDetails { get; set; }

        public Cart()
        {
            if (CartDetails == null)
            {
                CartDetails = new List<CartDetail>();
            }

        }

    }
}
