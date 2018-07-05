using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Web.ViewModels
{
    public class ArtistVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Born { get; set; }
        public int? Died { get; set; }
        public string Country { get; set; }
        public string Biography { get; set; }
        public List<ArtworkVM> Artworks { get; set; }
        public List<string> Styles { get; set; }
        public IEnumerable<Images> Images { get; set; }
        public int ImageId { get; set; }
        public virtual Images Image { get; set; }
    }
}
