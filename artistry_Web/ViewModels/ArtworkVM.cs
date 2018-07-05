using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Web.ViewModels
{
    public class ArtworkVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public int MuseumId { get; set; }
        public string Museum { get; set; }
        public int ImageId { get; set; }
        public virtual Images Image { get; set; }
        public string ArtworkType { get; set; }
        public int ArtworkTypeId { get; set; }
        public string Material { get; set; }
        public string Style { get; set; }
        public string Country { get; set; }
        public string Provenance { get; set; }
        public string CatalogueEntry { get; set; }
        public int Likes { get; set; }
        public bool Liked { get; set; }
        public IEnumerable<Images> Images { get; set; }
    }
}
