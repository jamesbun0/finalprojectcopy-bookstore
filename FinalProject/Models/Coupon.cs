using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FinalProject.Models
{
    public class Coupon
    {
        [Display(Name ="Coupon ID")]
        public Int32 CouponID { get; set; }

        [Required(ErrorMessage = "Coupon code is required.")]
        [StringLength(20, ErrorMessage = "Coupons must be 1-20 characters", MinimumLength = 1)]
        [Display(Name = "Coupon Code")]
        public String CouponCode { get; set; }

        [Required(ErrorMessage = "Coupon type is required.")]
        [Display(Name = "Coupon Type")]
        public String CouponType { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required.")]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public List<Cart> Carts { get; set; }

        public Boolean CouponStatus { get; set; }
    }
}
