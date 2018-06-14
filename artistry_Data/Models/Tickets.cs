using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.Models
{
    public class Tickets
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TicketTypeId { get; set; }
        public virtual TicketTypes TicketType { get; set; }
        public int ClientId { get; set; }
        public virtual Clients Client { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
        public string Code { get; set; }
        public bool Seen { get; set; }
        public bool Active { get; set; }
    }
}
