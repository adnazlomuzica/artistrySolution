using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Web.Areas.Moderator.ViewModels
{
    public class NewsVM
    {
        public int Id { get; set; }
        public string Title{get;set;}
        public string Subtitle { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public int MuseumId { get; set; }
        public int? ImageId { get; set; }
        public virtual Images Images { get; set; }
        public IEnumerable<Images> Img { get; set; }
    }
}
