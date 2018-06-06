using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.Models
{
    public class Likes
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public virtual Clients Client { get; set; }
        public int ArtworkId { get; set; }
        public virtual Artworks Artwork { get; set; }
    }
}
