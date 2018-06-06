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
        private readonly ICurrencyRepository currencyRepository;

        public TicketTypeController(Context context)
        {
            this.tickettypeRepository = new TicketTypeRepository(context);
            this.museumRepository = new MuseumRepository(context);
            this.currencyRepository = new CurrencyRepository(context);
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
            TicketTypes t = tickettypeRepository.GetType(id);

            TicketTypeVM model = new TicketTypeVM();

            model.Id = t.Id;
            model.CurrencyId = t.CurrencyId;
            model.MuseumId = t.MuseumId;
            model.Price = t.Price;
            model.Type = t.Type;

            model.Currencies = new SelectList(currencyRepository.GetCurrencies(), "Id", "Symbol");

            return View("Edit", model);
        }

        [HttpGet("Add")]
        public IActionResult Add()
        {
            TicketTypeVM model = new TicketTypeVM();

            int id = Autentification.GetLoggedUser(HttpContext).Id;

            model.MuseumId = museumRepository.GetMuseumByAccId(id).Id;
            model.Currencies = new SelectList(currencyRepository.GetCurrencies(), "Id", "Symbol");

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
        public IActionResult Save(TicketTypeVM model)
        {
            if (!ModelState.IsValid)
            {
                model.Currencies = new SelectList(currencyRepository.GetCurrencies(), "Id", "Symbol");
                return View("Add", model);
            }

            TicketTypes t = new TicketTypes();
            t.CurrencyId = model.CurrencyId;
            t.MuseumId = model.MuseumId;
            t.Price = model.Price;
            t.Type = model.Type;

            tickettypeRepository.InsertType(t);
            tickettypeRepository.Save();

            return RedirectToAction("Index");
        }

        [HttpPost("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TicketTypeVM model)
        {
            if (!ModelState.IsValid)
            {
                model.Currencies = new SelectList(currencyRepository.GetCurrencies(), "Id", "Symbol");
                return View("Edit", model);
            }

            TicketTypes t = new TicketTypes();
            t.Id = model.Id;
            t.CurrencyId = model.CurrencyId;
            t.MuseumId = model.MuseumId;
            t.Price = model.Price;
            t.Type = model.Type;

            tickettypeRepository.UpdateType(t);
            tickettypeRepository.Save();

            return RedirectToAction("Index");
        }
    }
}