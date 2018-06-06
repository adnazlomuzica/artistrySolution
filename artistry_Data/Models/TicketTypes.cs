using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.Models
{
    public class TicketTypes
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public int MuseumId { get; set; }
        public virtual Museums Museum { get; set; }
        public int CurrencyId { get; set; }
        public virtual Currencies Currency { get; set; }
    }
}
