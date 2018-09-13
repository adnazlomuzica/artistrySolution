using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Web.ViewModels
{
    public class CollectionVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MuseumId { get; set; }
        public string Description { get; set; }
        public List<ArtworkVM> Artworks { get; set; }
        public int ImageId { get; set; }
        public virtual Images Image { get; set; }
    }
}
