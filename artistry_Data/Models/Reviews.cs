using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.Models
{
    public class Reviews
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
        public int MuseumId { get; set; }
        public virtual Museums Museum { get; set; }
        public int ClientId { get; set; }
        public virtual Clients Client { get; set; }
    }
}
