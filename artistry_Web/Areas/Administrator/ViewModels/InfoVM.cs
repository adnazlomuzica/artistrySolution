using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Web.Areas.Administrator.ViewModels
{
    public class InfoVM
    {
        public int MuseumsRegistrated { get; set; }
        public int MuseumsRegMonth { get; set; }
        public int UsersRegistrated { get; set; }
        public int UsersRegMonth { get; set; }
        public int TicketsSale { get; set; }
        public int TicketsSaleMonth { get; set; }
        public double TicketsRevenue { get; set; }
        public double TicketsRevenueMonth { get; set; }
        public int ActiveMuseums { get; set; }
        public int InactiveMuseums { get; set; }
        public List<MuseumTicketSale> museumTicketSales { get; set; }
        public int TotalMuseumTicketSales { get; set; }
    }
}
