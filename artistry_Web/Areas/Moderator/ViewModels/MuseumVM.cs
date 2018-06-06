using artistry_Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Web.Areas.Moderator.ViewModels
{
    public class MuseumVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string RegistrationDate { get; set; }
        public string MuseumType { get; set; }
        public int MuseumTypeId { get; set; }
        public IEnumerable<SelectListItem> MuseumTypes { get; set; }
        public int Year { get; set; }
        public bool QrScanning { get; set; }
        public bool TicketSelling { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public IEnumerable<Images> Images { get; set; }
        public IEnumerable<WorkingHours> WorkingHour { get; set; }
    }
}
