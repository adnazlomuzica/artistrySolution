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
    public class ArtworkTypeController : Controller
    {
        private readonly IArtworkTypeRepository artworktypeRepository;
        public ArtworkTypeController(Context context)
        {
            this.artworktypeRepository = new ArtworkTypeRepository(context);
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            IEnumerable<ArtworkTypes> model = artworktypeRepository.GetArtworkTypes();
            return View(model);
        }

        [HttpGet]
        public IActionResult GetType(int id)
        {
            ArtworkTypes model = artworktypeRepository.GetType(id);
            return View("Edit", model);
        }

        [HttpGet("Add")]
        public IActionResult Add()
        {
            ArtworkTypes model = new ArtworkTypes();
            return View(model);
        }

        [HttpPost("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ArtworkTypes type)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", type);
            }
            artworktypeRepository.UpdateType(type);
            artworktypeRepository.Save();

            return RedirectToAction("Index");
        }

        [HttpPost("Save")]
        [ValidateAntiForgeryToken]
        public IActionResult Save(ArtworkTypes type)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", type);
            }
            artworktypeRepository.InsertType(type);
            artworktypeRepository.Save();

            return RedirectToAction("Index");
        }

        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            artworktypeRepository.DeleteType(id);
            artworktypeRepository.Save();

            return RedirectToAction("Index");
        }
    }
}