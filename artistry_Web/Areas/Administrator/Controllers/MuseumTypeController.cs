using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using artistry_Data.Context;
using artistry_Data.DAL;
using artistry_Data.Models;
using artistry_Web.Helper;
using Microsoft.AspNetCore.Mvc;

namespace artistry_Web.Areas.Administrator.Controllers
{
    [Authorization(true, false, false)]
    [Area("Administrator")]
    [Route("Administrator/[controller]")]
    public class MuseumTypeController : Controller
    {
        private readonly IMuseumRepository museumRepository;
        private readonly IMuseumTypeRepository museumtypeRepository;

        public MuseumTypeController(Context context)
        {
            this.museumtypeRepository = new MuseumTypeRepository(context);
            this.museumRepository = new MuseumRepository(context);
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
           IEnumerable<MuseumTypes> model= museumtypeRepository.GetMuseumTypes();
           return View(model);
        }

        [HttpGet]
        public IActionResult GetType(int id)
        {
            MuseumTypes model = museumtypeRepository.GetMuseumType(id);
            return View("Edit", model);
        }

        [HttpGet("Add")]
        public IActionResult Add()
        {
            MuseumTypes model = new MuseumTypes();
            return View(model);
        }

        [HttpPost("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MuseumTypes type)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", type);
            }
            museumtypeRepository.UpdateMuseumType(type);
            museumtypeRepository.Save();

            return RedirectToAction("Index");
        }

        [HttpPost("Save")]
        [ValidateAntiForgeryToken]
        public IActionResult Save(MuseumTypes type)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", type);
            }
            museumtypeRepository.InsertMuseumType(type);
            museumtypeRepository.Save();

            return RedirectToAction("Index");
        }

        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            List<Museums> museums = museumRepository.GetMuseumsByType(id);
            int n=museums.Count();

            if (n == 0)
            {
                museumtypeRepository.DeleteMuseumType(id);
                museumtypeRepository.Save();
            }

            return RedirectToAction("Index");
        }
    }
}