using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.Models
{
    public class WorkingHours
    {
        public int Id { get; set; }
        public int Day { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
        public int MuseumId { get; set; }
        public virtual Museums Museum { get; set; }
    }
}
