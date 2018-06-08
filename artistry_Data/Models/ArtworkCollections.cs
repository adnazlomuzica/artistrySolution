using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.Models
{
    public class ArtworkCollections
    {
        public int Id { get; set; }
        public int ArtworkId { get; set; }
        public virtual Artworks Artwork { get; set; }
        public int CollectionId { get; set; }
        public virtual Collections Collection { get; set; }
    }
}
