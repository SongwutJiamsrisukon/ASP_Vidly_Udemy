using ASP_Vidly_Udemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_Vidly_Udemy.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; } //using Instead List (need to read only we don't include add remove or etc)
        public Customer Customer { get; set; }
    }
}