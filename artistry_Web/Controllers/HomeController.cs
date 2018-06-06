using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using artistry_Web.Models;
using artistry_Data.Context;
using artistry_Data.Models;
using artistry_Web.Helper;
using Microsoft.AspNetCore.Diagnostics;

namespace artistry_Web.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly Context db;
        public HomeController(Context context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            UserAccounts u = Autentification.GetLoggedUser(HttpContext);

            if (u == null)
            {
                return RedirectToAction("Index", "Autentification");
            }

            Administrators admin = db.Administrators.SingleOrDefault(x => x.UserId == u.Id);
            Museums museum = db.Museums.SingleOrDefault(x => x.UserId == u.Id);
            //Clients client = db.Clients.SingleOrDefault(x => x.UserId == u.Id); 

            if (admin != null)
            {
                return RedirectToAction("Index", "Home", new { area = "Administrator" });
            }

            else if (museum != null)
            {
                return RedirectToAction("Index", "Home", new { area = "Moderator" });
            }

            else
            {
                return RedirectToAction("Index", "Home", new { area = "Client" });
            }

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [Route("/Error")]
        public IActionResult Error()
        {
            // Get the details of the exception that occurred
          
                // TODO: Do something with the exception
                // Log it with Serilog?
                // Send an e-mail, text, fax, or carrier pidgeon?  Maybe all of the above?
                // Whatever you do, be careful to catch any exceptions, otherwise you'll end up with a blank page and throwing a 500

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
