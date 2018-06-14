using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Web.Areas.Moderator.ViewModels
{
    public class InfoVM
    {
        public int TicketsSold { get; set; }
        public double Total { get; set; }
        public int MonthTicketsSold { get; set; }
        public double MonthTotal { get; set; }
        public double AverageRating { get; set; }
        public double MonthAverageRating{get;set;}
        public int ActiveTickets { get; set; }
        public int DayActiveTickets { get; set; }
        public IEnumerable<Tickets> LatestTickets { get; set; }
        public IEnumerable<Reviews> LatestReviews { get; set; }
        public bool result { get; set; }
    }
}
