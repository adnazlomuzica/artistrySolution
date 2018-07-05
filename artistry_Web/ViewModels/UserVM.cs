using artistry_Web.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Web.ViewModels
{
    public class UserVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Please enter your first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your username")]
        [StringLength(100, ErrorMessage = "Username must have at least 4 characters", MinimumLength = 4)]
        [ValidationExstension]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [ValidationExstension]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [RegularExpression(pattern: "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Password must contain at least 8 characters, at least one number, upper-case letter and special character")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please repeat password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Password does not match")]
        public string ConfirmPassword { get; set; }
    }
}
