using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using artistry_Data.Context;
using artistry_Data.DAL;
using artistry_Data.Models;
using artistry_Web.Areas.Moderator.ViewModels;
using artistry_Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace artistry_Web.Areas.Moderator.Controllers
{
    [Authorization(false, true, false)]
    [Area("Moderator")]
    [Route("Moderator/[controller]")]
    public class TicketTypeController : Controller
    {
        private readonly ITicketTypeRepository tickettypeRepository;
        private readonly IMuseumRepository museumRepository;

        public TicketTypeController(Context context)
        {
            this.tickettypeRepository = new TicketTypeRepository(context);
            this.museumRepository = new MuseumRepository(context);
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            int Id = Autentification.GetLoggedUser(HttpContext).Id;
            Museums m = museumRepository.GetMuseumByAccId(Id);

            IEnumerable<TicketTypes> model = tickettypeRepository.GetTicketTypes(m.Id);
            ViewData["Allow"] = m.OnlineTickets;

 
            return View("Index", model);
        }

        [HttpGet("GetType")]
        public IActionResult GetType(int id)
        {
            TicketTypes model = tickettypeRepository.GetType(id);
         
            return View("Edit", model);
        }

        [HttpGet("Add")]
        public IActionResult Add()
        {
            TicketTypes model = new TicketTypes();

            int id = Autentification.GetLoggedUser(HttpContext).Id;

            model.MuseumId = museumRepository.GetMuseumByAccId(id).Id;

            return View("Add", model);
        }

        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            tickettypeRepository.DeleteType(id);
            tickettypeRepository.Save();

            return RedirectToAction("Index");
        }

        [HttpPost("Save")]
        [ValidateAntiForgeryToken]
        public IActionResult Save(TicketTypes model)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", model);
            }

            tickettypeRepository.InsertType(model);
            tickettypeRepository.Save();

            return RedirectToAction("Index");
        }

        [HttpPost("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TicketTypes model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            }

            tickettypeRepository.UpdateType(model);
            tickettypeRepository.Save();

            return RedirectToAction("Index");
        }
    }
}