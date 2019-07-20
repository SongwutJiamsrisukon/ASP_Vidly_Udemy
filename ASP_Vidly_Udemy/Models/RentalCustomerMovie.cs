using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_Vidly_Udemy.Models
{
    public class RentalCustomerMovie
    {
        public int Id { get; set; }//autoincrement by Framework

        [Required]
        public Customer Customer { get; set; }
        [Required]
        public Movie Movie { get; set; }

        public DateTime DateRented { get; set; }//unnullable
        public DateTime? DateReturned { get; set; }//nullable
    }
}