using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Web.Areas.Administrator.ViewModels
{
    public class ArtistInfoVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Born { get; set; }
        public int? Died { get; set; }
        public string Biography { get; set; }
        public string Country { get; set; }
        public IEnumerable<ArtistMovements> Styles { get; set; }
        public IEnumerable<Artworks> Artworks { get; set; }
    }
}
