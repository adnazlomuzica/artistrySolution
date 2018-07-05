using artistry_Data.Helper;
using artistry_Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Web.Areas.Administrator.ViewModels
{
    public class MuseumVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the museum name")]
        [StringLength(100, ErrorMessage = "Name must have at least 3 characters", MinimumLength = 3)]
        public string Name { get; set; }

        public int UserId { get; set; }

        [Required(ErrorMessage = "Please enter the username")]
        [StringLength(100, ErrorMessage = "Username must have at least 4 characters", MinimumLength = 4)]
        [ValidationExstension]
        public string Username { get; set; }

        public string PasswordSalt { get; set; }

        public string PasswordHash { get; set; }

        public int MuseumTypeId { get; set; }
        public IEnumerable<SelectListItem> MuseumType { get; set; }

        [RegularExpression(pattern: "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Password must contain at least 8 characters, at least one number, upper-case letter and special character")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        public string RepeatPassword { get; set; }


    }
}
