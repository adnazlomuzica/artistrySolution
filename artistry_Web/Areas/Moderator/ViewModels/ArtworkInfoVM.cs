using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Web.Areas.Moderator.ViewModels
{
    public class ArtworkInfoVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set; }
        public string Artist { get; set; }
        public int Likes { get; set; }
        public int? ImageId { get; set; }
        public Images Image { get; set; }
    }
}
