using artistry_Data.Models;
using artistry_Web.Helper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Web.Areas.Moderator.ViewModels
{
    public class ArtworkVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter name")]
        [StringLength(100, ErrorMessage = "Name must have at least 3 characters", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter date")]
        public string Date { get; set; }

        [Required(ErrorMessage = "Please enter accession number")]
        [ValidationExstension]
        public int AccessionNumber { get; set; }

        [Required(ErrorMessage = "Please select country")]
        public int CountryId { get; set; }
        public IEnumerable<SelectListItem> Country { get; set; }

        [Required(ErrorMessage = "Please select style")]
        public int StyleId { get; set; }
        public  IEnumerable<SelectListItem> Style { get; set; }

        [Required(ErrorMessage = "Please select material")]
        public int MaterialId { get; set; }
        public IEnumerable<SelectListItem> Material { get; set; }

        [Required(ErrorMessage = "Please select artwork type")]
        public int ArtworkTypeId { get; set; }
        public IEnumerable<SelectListItem> ArtworkType { get; set; }

        [Required(ErrorMessage = "Please select artist")]
        public int ArtistId { get; set; }
        public IEnumerable<SelectListItem> Artist { get; set; }
        public int MuseumId { get; set; }
        public bool Active { get; set; }
        public string Provenance { get; set; }

        [Required(ErrorMessage = "Please enter description")]
        public string CatalogueEntry { get; set; }
        public IEnumerable<Images> Images { get; set; }
        public string Country_S { get; set; }
        public string Style_S { get; set; }
        public string Material_S { get; set; }
        public string ArtworkType_S { get; set; }
        public string Artist_S { get; set; }
    }
}
