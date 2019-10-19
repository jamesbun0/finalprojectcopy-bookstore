using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Genre
    {
        [Display(Name = "Genre ID")]
        public Int32 GenreID { get; set; }

        [Display(Name = "Genre Name")]
        public String GenreName { get; set; }

        public List<Book> Books {get; set;}

        public Genre()
        {
            if (Books == null)
            {
                Books = new List<Book>();
            }

        }
    }
}
