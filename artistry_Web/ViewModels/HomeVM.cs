using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Web.ViewModels
{
    public class HomeVM
    {
        public List<MuseumVM> Museums { get; set; }
        public List<ArtworkVM> Artworks { get; set; }
        public List<NewsVM> News { get; set; }
    }
}
