using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Web.ViewModels
{
    public class MuseumVM
    {
        public int Id { get; set; }
        public string Name{ get;set;}
        public string Description { get; set; }
        public int ImageId { get; set; }
        public virtual Images Image { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int UserId { get; set; }
        public int OpeningYear { get; set; }
        public bool TicketSelling { get; set; }
        IEnumerable<Images> Images { get; set; }
    }
}
