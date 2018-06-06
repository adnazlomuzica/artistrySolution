using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.Models
{
    public class Museums
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int UserId { get; set; }
        public virtual UserAccounts User { get; set; }
        public int MuseumTypeId { get; set; }
        public virtual MuseumTypes MuseumType { get; set; }
        public string Description { get; set; }
        public int OpeningYear { get; set; }
        public bool QrScanning { get; set; }
        public bool OnlineTickets { get; set; }

    }
}
