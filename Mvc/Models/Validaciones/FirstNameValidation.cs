using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Models.Validaciones
{
    public class FirstNameValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("El nombre es un valor requerido.");
            } 
            else
            {
                if (value.ToString().Contains("@"))
                {
                    return new ValidationResult("El nombre no debería contener @");
                }
            }

            return ValidationResult.Success;

            //return base.IsValid(value, validationContext);
        }
    }
}