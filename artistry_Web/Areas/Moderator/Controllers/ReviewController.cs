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
    public class ReviewController : Controller
    {
        private readonly IReviewRepository reviewRepository;

        public ReviewController(Context context)
        {
            this.reviewRepository = new ReviewRepository(context);
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            int Id = Autentification.GetLoggedUser(HttpContext).Id;
            List<Reviews> model = reviewRepository.GetReviews(Id);

            return View("Index", model);
        }
    }
}