using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_API.Models
{
    public class ArtworkVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }
        public string Artist { get; set; }
        public string Type { get; set; }
        public string Material { get; set; }
        public string Style { get; set; }
        public string Description { get; set; }
    }
}
