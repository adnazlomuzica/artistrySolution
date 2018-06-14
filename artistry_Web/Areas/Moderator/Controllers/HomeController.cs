using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using artistry_Data.Context;
using artistry_Data.DAL;
using artistry_Web.Areas.Moderator.ViewModels;
using artistry_Web.Helper;
using Microsoft.AspNetCore.Mvc;

namespace artistry_Web.Areas.Moderator.Controllers
{
    [Authorization(false, true, false)]
    [Area("Moderator")]
    [Route("Moderator/[controller]")]
    public class HomeController : Controller
    {
        private readonly ITicketRepository ticketRepository;
        private readonly IReviewRepository reviewRepository;

        public HomeController(Context context)
        {
            this.ticketRepository = new TicketRepository(context);
            this.reviewRepository = new ReviewRepository(context);
        }

        [HttpGet("Index")]
        public IActionResult Index(bool? r)
        {
            InfoVM model = new InfoVM();

            if (r == null)
                r = true;

            int Id = Autentification.GetLoggedUser(HttpContext).Id;
            model.ActiveTickets = ticketRepository.GetTickets(Id).Where(x => x.Active).Count();
            model.DayActiveTickets= ticketRepository.GetTickets(Id).Where(x => x.Active && x.Date.Day==DateTime.Now.Day).Count();
            model.AverageRating = reviewRepository.AverageRating(Id);
            model.LatestReviews = reviewRepository.GetReviews(Id).Take(4);
            model.LatestTickets = ticketRepository.GetTickets(Id).Take(10);
            model.MonthAverageRating = reviewRepository.MonthAverageRating(Id);
            model.MonthTicketsSold = ticketRepository.GetMonthSum(Id);
            model.MonthTotal = ticketRepository.GetMonthTotal(Id);
            model.result = Convert.ToBoolean(r);
            model.TicketsSold = ticketRepository.GetSum(Id);
            model.Total = ticketRepository.GetTotal(Id);
           
            return View("Index",model);
        }

        [HttpPost("Scan")]
        [ValidateAntiForgeryToken]
        public IActionResult Scan(string code)
        {
            bool result = ticketRepository.Scan(code);

            return RedirectToAction("Index", new { r = result});
        }
    }
}