using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Web.ViewModels
{
    public class LoginVM
    {
        [StringLength(100, ErrorMessage ="Korisnicko ime mora sadrzavati minimalno 5 karaktera!", MinimumLength =5)]
        public string Username { get; set; }

        [StringLength(100, ErrorMessage = "Lozinka mora sadrzavati minimalno 5 karaktera!", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberPassword { get; set; }
    }
}
