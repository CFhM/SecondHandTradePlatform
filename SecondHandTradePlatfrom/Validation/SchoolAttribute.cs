using SecondHandTradePlatfrom.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SecondHandTradePlatfrom.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple =false)]
    public class SchoolAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(value is string school))
            {
                return new ValidationResult("The value is not a valid string.");
            }

            var query = validationContext.GetService<DatabaseContext>();
            var schoolRetrived = query.Schools.FirstOrDefault(val => val.name == school);
            if (schoolRetrived == null)
            {
                return new ValidationResult("It is not a supportted school name");
            }
            return ValidationResult.Success;

            
        }
    }
}
