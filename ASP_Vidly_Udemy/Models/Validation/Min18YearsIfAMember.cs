﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace ASP_Vidly_Udemy.Models.Validation
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;//validationContext.ObjectInstance is object

            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;//use when success

            if(customer.BirthDate == null)
            {
                return new ValidationResult("Birthdate is required.");
            }

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age>=18)?ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 years old to go on a membership ");
        }
    }
}