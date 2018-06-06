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
    public class MaterialController : Controller
    {
        private readonly IMaterialRepository materialRepository;
        public MaterialController(Context context)
        {
            this.materialRepository = new MaterialRepository(context);
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            IEnumerable<Materials> model = materialRepository.GetMaterials();
            return View(model);
        }

        [HttpGet]
        public IActionResult GetMaterial(int id)
        {
            Materials model = materialRepository.GetMaterial(id);
            return View("Edit", model);
        }

        [HttpGet("Add")]
        public IActionResult Add()
        {
            Materials model = new Materials();
            return View(model);
        }

        [HttpPost("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Materials material)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", material);
            }
            materialRepository.UpdateMaterial(material);
            materialRepository.Save();

            return RedirectToAction("Index");
        }

        [HttpPost("Save")]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Materials material)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", material);
            }
            materialRepository.InsertMaterial(material);
            materialRepository.Save();

            return RedirectToAction("Index");
        }

        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            materialRepository.DeleteMaterial(id);
            materialRepository.Save();

            return RedirectToAction("Index");
        }
    }
}