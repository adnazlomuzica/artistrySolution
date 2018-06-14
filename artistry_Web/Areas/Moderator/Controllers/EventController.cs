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

        [HttpGet("GetEvent")]
        public IActionResult GetEvent(int id)
        {
            Events e = eventRepository.GetEventById(id);

            return View("Edit", e);
        }

        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            Events e = eventRepository.GetEventById(id);

            return View("Details", e);
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

        [HttpPost("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Events model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            }

            eventRepository.UpdateEvent(model);
            eventRepository.Save();

            return RedirectToAction("Index");
        }

        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            eventRepository.DeleteEvent(id);
            eventRepository.Save();

            return RedirectToAction("Index");
        }

        [HttpGet("GetEvents")]
        public JsonResult GetEvents(DateTime start, DateTime end)
        {
            int id = Autentification.GetLoggedUser(HttpContext).Id;
            Museums m = museumRepository.GetMuseumByAccId(id);

            List<Events> list = eventRepository.GetEvents(m.Id);
            list = list.Where(x => x.StartDate >= start && x.EndTime <= end).ToList();
            var eventList = from e in list
                            select new
                            {
                                id = e.Id,
                                title = e.Title,
                                start = e.StartDate,
                                end = e.EndTime,
                                color = "Teal",
                                someKey = e.Id +1,
                                allDay = false
                            };
            var rows = eventList.ToArray();
            return Json(rows);
        }
    }
}