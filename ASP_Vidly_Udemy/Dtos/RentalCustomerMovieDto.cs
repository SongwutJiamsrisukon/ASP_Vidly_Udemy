using ASP_Vidly_Udemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_Vidly_Udemy.Dtos
{
    public class RentalCustomerMovieDto
    {
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}