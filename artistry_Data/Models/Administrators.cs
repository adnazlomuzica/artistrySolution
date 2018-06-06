using artistry_Data.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.Models
{
    public class Administrators
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter first name")]
        [StringLength(100, ErrorMessage ="First name must have at least 3 characters!",MinimumLength = 3)]
        public string FirstName { get; set; }

        [StringLength(100, ErrorMessage = "Last name must have at least 3 characters!", MinimumLength = 3)]
        [Required(ErrorMessage = "Please enter last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Please enter email")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Invalid email type")]
        [ValidationExstension]
        public string Email { get; set; }
        
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter address")]
        public string Address { get; set; }

        public int UserId { get; set; }
        public virtual UserAccounts User { get; set; }
    }
}
