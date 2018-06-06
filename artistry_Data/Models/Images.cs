using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.Models
{
    public class Images
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public byte[] Image { get; set; }
        public byte[] ImageThumb { get; set; }
        public bool Primary { get; set; }
        public int? MuseumId { get; set; }
        public virtual Museums Museum { get; set; }
        public int? ArtistId {get;set;}
        public virtual Artists Artist { get; set; }
        public int? ArtworkId { get; set; }
        public virtual Artworks Artwork { get; set; }
    }
}
