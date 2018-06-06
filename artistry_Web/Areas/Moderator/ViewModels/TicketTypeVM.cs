using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Web.Areas.Moderator.ViewModels
{
    public class TicketTypeVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter type")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Please enter price")]
        public double Price { get; set; }
        public int MuseumId { get; set; }
        public int CurrencyId { get; set; }
        public IEnumerable<SelectListItem> Currencies { get; set; }
    }
}
