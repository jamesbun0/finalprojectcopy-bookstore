using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class BookProcurement
    {
        [Display(Name = "Book Procurement ID")]
        public Int32 BookProcurementID { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Total")]
        public Decimal Total { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Display(Name = "Quantity")]
        public Int32 Quantity { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Price")]
        [Range(typeof(decimal), "0.00000001", "79228162514264337593543")]
        public Decimal Price { get; set; }

        [Required(ErrorMessage = "Procurement date is required.")]
        [Display(Name = "Procurement Date")]
        public DateTime ProcurementDate { get; set; }

        public String UserName { get; set; }

        public Book Book { get; set; }
    }
}
