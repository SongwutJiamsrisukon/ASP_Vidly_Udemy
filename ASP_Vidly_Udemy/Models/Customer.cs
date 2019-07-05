using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_Vidly_Udemy.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Membership Type")]
        public MembershipType MembershipType { get; set; }//Navagation property 

        public byte MembershipTypeId { get; set; }//foreignkey auto generate by entityFramework

        [Display(Name="Date Of Birth")]
        public DateTime? BirthDate { get; set; }

    }
}