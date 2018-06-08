using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.Models
{
    public class Events
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MuseumId { get; set; }
        public virtual Museums Museum { get; set; }
    }
}
