using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.Models
{
    public class Artworks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public int AccessionNumber { get; set; }
        public int CountryId { get; set; }
        public virtual Countries Country { get; set; }
        public int StyleId { get; set; }
        public virtual Styles Style { get; set; }
        public int MaterialId { get; set; }
        public virtual Materials Material { get; set; }
        public int ArtworkTypeId { get; set; }
        public virtual ArtworkTypes ArtworkType { get; set; }
        public int ArtistId { get; set; }
        public virtual Artists Artist { get; set; }
        public int MuseumId { get; set; }
        public virtual Museums Museum { get; set; }
        public bool Active { get; set; }
        public string Provenance { get; set; }
        public string CatalogueEntry { get; set; }
    }
}
