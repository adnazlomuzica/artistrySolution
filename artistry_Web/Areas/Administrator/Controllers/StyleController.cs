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
    public class StyleController : Controller
    {
        private readonly IStyleRepository styleRepository;
        public StyleController(Context context)
        {
            this.styleRepository = new StyleRepository(context);
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            IEnumerable<Styles> model = styleRepository.GetStyles();
            return View(model.OrderBy(x=>x.Name));
        }

        [HttpGet]
        public IActionResult GetStyle(int id)
        {
            Styles model = styleRepository.GetStyle(id);
            return View("Edit", model);
        }

        [HttpGet("Add")]
        public IActionResult Add()
        {
            Styles model = new Styles();
            return View(model);
        }

        [HttpPost("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Styles style)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", style);
            }
            styleRepository.UpdateStyle(style);
            styleRepository.Save();

            return RedirectToAction("Index");
        }

        [HttpPost("Save")]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Styles style)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", style);
            }
            styleRepository.InsertStyle(style);
            styleRepository.Save();

            return RedirectToAction("Index");
        }

        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            styleRepository.DeleteStyle(id);
            styleRepository.Save();

            return RedirectToAction("Index");
        }
    }
}