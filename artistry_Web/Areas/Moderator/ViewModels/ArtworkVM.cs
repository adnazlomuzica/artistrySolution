using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Web.Areas.Moderator.ViewModels
{
    public class ArtworkVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public int AccessionNumber { get; set; }
        public int CountryId { get; set; }
        public IEnumerable<SelectListItem> Country { get; set; }
        public int StyleId { get; set; }
        public  IEnumerable<SelectListItem> Style { get; set; }
        public int MaterialId { get; set; }
        public IEnumerable<SelectListItem> Material { get; set; }
        public int ArtworkTypeId { get; set; }
        public IEnumerable<SelectListItem> ArtworkType { get; set; }
        public int ArtistId { get; set; }
        public IEnumerable<SelectListItem> Artist { get; set; }
        public int MuseumId { get; set; }
        public bool Active { get; set; }
        public string Provenance { get; set; }
        public string CatalogueEntry { get; set; }
    }
}
