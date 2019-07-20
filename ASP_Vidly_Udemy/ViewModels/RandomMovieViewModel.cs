using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ASP_Vidly_Udemy.Models;

namespace ASP_Vidly_Udemy.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}