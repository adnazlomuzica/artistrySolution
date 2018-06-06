using artistry_Data.Context;
using artistry_Data.Models;
using artistry_Web.Areas.Administrator.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Web.Helper
{
    public class ValidationExstension:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Context db = (Context)validationContext.GetService(typeof(Context));

            
            var className = validationContext.ObjectType.Name.Split('.').Last();
            var propertyName = validationContext.MemberName;
            var parameterName = string.Format("@{0}", propertyName);

            
            if (className == "MuseumVM")
            {
                var obj = validationContext.ObjectInstance as MuseumVM;
                var  result = db.Museums.Where(x => x.User.Username == value.ToString() && x.Id!=obj.Id).ToList();
                if (result.Count() > 0)
                {
                    return new ValidationResult(string.Format("The {0} already exist", propertyName),
                                new List<string>() { propertyName });
                }
                else
                {
                    return ValidationResult.Success;
                }
            }

            return ValidationResult.Success;
        }
    }
}
