using artistry_Data.Context;
using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.Helper
{
    public class ValidationExstension:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Context.Context db = (Context.Context)validationContext.GetService(typeof(Context.Context));

            var className = validationContext.ObjectType.Name.Split('.').Last();
            var propertyName = validationContext.MemberName;
            var parameterName = string.Format("@{0}", propertyName);

            
            if (className == "Administrators")
            {
                var obj = validationContext.ObjectInstance as Administrators;
                var  result = db.Administrators.Where(x => x.Email == value.ToString() && x.Id!=obj.Id).ToList();
                if (result.Count() > 0)
                {
                    return new ValidationResult(string.Format("The email already exists", propertyName),
                                new List<string>() { propertyName });
                }
            }

            else if (className == "UserAccounts")
            {
                var obj = validationContext.ObjectInstance as UserAccounts;
                var result = db.UserAccounts.Where(x => x.Username == value.ToString() && x.Id!=obj.Id).ToList();
                if (result.Count() > 0)
                {
                    return new ValidationResult(string.Format("The username already exists", propertyName),
                                new List<string>() { propertyName });
                }
            }

            return null;
        }
    }
}
