using artistry_Data.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.Models
{
    public class UserAccounts
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter username")]
        [StringLength(100, ErrorMessage = "Username must have at least 4 characters!", MinimumLength = 4)]
        [ValidationExstension]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [RegularExpression(pattern: "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Password must contain at least 8 characters, at least one number, upper-case letter and special character")]
        public string PasswordHash {get;set;}
        public string PasswordSalt { get; set; }
        public bool Active { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
