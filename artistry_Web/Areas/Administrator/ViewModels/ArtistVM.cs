using artistry_Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Web.Areas.Administrator.ViewModels
{
    public class ArtistVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter artist name")]
        [StringLength(100, ErrorMessage = "Name must have at least 3 characters", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter year")]
        public int Born { get; set; }

        public int? Died { get; set; }
        public string Biography { get; set; }
        public int CountryId { get; set; }
        public IEnumerable<SelectListItem> Country { get; set; }

        [Required(ErrorMessage = "Please select style")]
        public List<int> StyleId { get; set; }
        public IEnumerable<SelectListItem> Style { get; set; }
    }
}
