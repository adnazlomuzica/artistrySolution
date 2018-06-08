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
    public class EventController : Controller
    {
        private readonly IEventRepository eventRepository;
        private readonly IMuseumRepository museumRepository;

        public EventController(Context context)
        {
            this.eventRepository = new EventRepository(context);
            this.museumRepository = new MuseumRepository(context);
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {            
            return View("Index");
        }

        [HttpGet("Add")]
        public IActionResult Add()
        {
            int id = Autentification.GetLoggedUser(HttpContext).Id;
            Museums m = museumRepository.GetMuseumByAccId(id);

            Events model = new Events();
            model.MuseumId = m.Id;

            model.StartDate = DateTime.Now;
            model.EndTime = DateTime.Now;

            return View("Add", model);
        }

        [HttpPost("Save")]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Events model)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", model);
            }

            eventRepository.InsertEvent(model);
            eventRepository.Save();

            return RedirectToAction("Index");
        }
    }
}