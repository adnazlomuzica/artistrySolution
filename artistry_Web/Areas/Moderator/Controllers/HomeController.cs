using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using artistry_Data.Context;
using artistry_Web.Helper;
using Microsoft.AspNetCore.Mvc;

namespace artistry_Web.Areas.Moderator.Controllers
{
    [Authorization(false, true, false)]
    [Area("Moderator")]
    [Route("Moderator/[controller]")]
    public class HomeController : Controller
    {
        private readonly Context db;
        public HomeController(Context context)
        {
            db = context;
        }
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}