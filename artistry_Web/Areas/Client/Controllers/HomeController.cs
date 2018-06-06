using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using artistry_Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace artistry_Web.Areas.Client.Controllers
{
    [Area("Client")]
    [Route("Client/[controller]")]
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