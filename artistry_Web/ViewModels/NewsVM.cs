using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Web.ViewModels
{
    public class NewsVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Text { get; set; }
        public string Museum { get; set; }
        public DateTime Date { get; set; }
        public int ImageId { get; set; }
        public virtual Images Image { get; set; }
        public IEnumerable<Images> Images { get; set; }
    }
}
