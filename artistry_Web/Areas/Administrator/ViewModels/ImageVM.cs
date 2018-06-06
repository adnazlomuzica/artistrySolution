using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Web.Areas.Administrator.ViewModels
{
    public class ImageIndexVM
    {
        [Key]
        public int Id { get; set; }
        public string Caption { get; set; }
    }

    public class ImageVM
    {
        [Key]
        public int ArtistId { get; set; }
        public List<ImageIndexVM> Images { get; set; }
    }
}
