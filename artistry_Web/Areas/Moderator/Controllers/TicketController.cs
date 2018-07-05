using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using artistry_Data.Context;
using artistry_Data.DAL;
using artistry_Data.Models;
using artistry_Web.Helper;
using Microsoft.AspNetCore.Mvc;

namespace artistry_Web.Areas.Moderator.Controllers
{
    [Authorization(false, true, false)]
    [Area("Moderator")]
    [Route("Moderator/[controller]")]
    public class TicketController : Controller
    {
        private readonly ITicketRepository ticketRepository;

        public TicketController(Context context)
        {
            this.ticketRepository = new TicketRepository(context);
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            int Id = Autentification.GetLoggedUser(HttpContext).Id;
            List<Tickets> model = ticketRepository.GetTickets(Id);

            ViewData["StartDate"] = DateTime.Now;
            ViewData["EndDate"] = DateTime.Now;

            return View("Index", model);
        }

        [HttpGet("Filter")]
        public IActionResult Filter(string startDate, string endDate)
        {
            int Id = Autentification.GetLoggedUser(HttpContext).Id;
            List<Tickets> model = ticketRepository.Filter(Id, Convert.ToDateTime(startDate), Convert.ToDateTime(endDate));

            return View("Index", model);
        }
    }
}