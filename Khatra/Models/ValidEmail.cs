using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Khatra.Resources.ViewsResources;

namespace Khatra.Models
{
    public class ValidEmail : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var user = (RegisterViewModel)validationContext.ObjectInstance;

            if (user.Email.Contains("gmail") || user.Email.Contains("hotmail") || user.Email.Contains("outlook") || user.Email.Contains("yahoo"))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(global.ValidEmail);
            }
        }
    }
}