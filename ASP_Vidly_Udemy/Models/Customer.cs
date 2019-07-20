using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using ASP_Vidly_Udemy.Models.Validation;

namespace ASP_Vidly_Udemy.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }//Navagation property 

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }//foreignkey auto generate by entityFramework


        [Display(Name="Date Of Birth")]
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }

    }
}