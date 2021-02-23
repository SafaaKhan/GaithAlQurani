using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GaithAlQuraniProject.Models
{
    public class ButtonMustBeShown: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var news = (News)validationContext.ObjectInstance;

            if (  news.ButtonStatus == "لا" ||(news.ButtonLink != null && news.ButtonContent!=null))
                return ValidationResult.Success;

            return new ValidationResult("عنوان الزر و الرابط مطلوب");
        }
    }
}
