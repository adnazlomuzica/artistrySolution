using artistry_Data.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.Models
{
    public class MuseumTypes
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the name")]
        [StringLength(100, ErrorMessage = "Name must have at least 3 characters!", MinimumLength = 3)]
        public string Name { get; set; }
    }
}
