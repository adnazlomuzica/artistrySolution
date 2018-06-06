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

namespace artistry_Web.Areas.Moderator.Controllers
{
    [Authorization(false, true, false)]
    [Area("Moderator")]
    [Route("Moderator/[controller]")]
    public class WorkingHoursController : Controller
    {
        private readonly IWorkingHourRepository workinghourRepository;

        public WorkingHoursController(Context context)
        {
            this.workinghourRepository = new WorkingHourRepository(context);
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Add")]
        public IActionResult Add(int id)
        {
            WorkingHourVM model = new WorkingHourVM();

            model.MuseumId = id;

            return View("Add", model);
        }

        [HttpPost("Save")]
        public IActionResult Save(WorkingHourVM model)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", model);
            }

            IEnumerable<WorkingHours> workingHours = workinghourRepository.GetWorkingHours(model.MuseumId);

            if (model.Monday)
            {
                WorkingHours wh = new WorkingHours();
                wh.MuseumId = model.MuseumId;
                wh.OpenTime = model.startTime;
                wh.CloseTime = model.endTime;
                wh.Day = 1;
                if (workingHours.Where(x => x.Day == 1).Count() != 0)
                    workinghourRepository.UpdateHours(wh);               
                else
                    workinghourRepository.InsertHours(wh);            
            }

            if (model.Tuesday)
            {
                WorkingHours wh = new WorkingHours();
                wh.MuseumId = model.MuseumId;
                wh.OpenTime = model.startTime;
                wh.CloseTime = model.endTime;
                wh.Day = 2;
                if (workingHours.Where(x => x.Day == 2).Count() != 0)
                    workinghourRepository.UpdateHours(wh);
                else
                    workinghourRepository.InsertHours(wh);
            }

            if (model.Wednesday)
            {
                WorkingHours wh = new WorkingHours();
                wh.MuseumId = model.MuseumId;
                wh.OpenTime = model.startTime;
                wh.CloseTime = model.endTime;
                wh.Day = 3;
                if (workingHours.Where(x => x.Day == 3).Count() != 0)
                    workinghourRepository.UpdateHours(wh);
                else
                    workinghourRepository.InsertHours(wh);
            }

            if (model.Thursday)
            {
                WorkingHours wh = new WorkingHours();
                wh.MuseumId = model.MuseumId;
                wh.OpenTime = model.startTime;
                wh.CloseTime = model.endTime;
                wh.Day = 4;
                if (workingHours.Where(x => x.Day == 4).Count() != 0)
                    workinghourRepository.UpdateHours(wh);
                else
                    workinghourRepository.InsertHours(wh);
            }

            if (model.Friday)
            {
                WorkingHours wh = new WorkingHours();
                wh.MuseumId = model.MuseumId;
                wh.OpenTime = model.startTime;
                wh.CloseTime = model.endTime;
                wh.Day = 5;
                if (workingHours.Where(x => x.Day == 5).Count() != 0)
                    workinghourRepository.UpdateHours(wh);
                else
                    workinghourRepository.InsertHours(wh);
            }

            if (model.Saturday)
            {
                WorkingHours wh = new WorkingHours();
                wh.MuseumId = model.MuseumId;
                wh.OpenTime = model.startTime;
                wh.CloseTime = model.endTime;
                wh.Day = 6;
                if (workingHours.Where(x => x.Day == 6).Count() != 0)
                    workinghourRepository.UpdateHours(wh);
                else
                    workinghourRepository.InsertHours(wh);
            }

            if (model.Sunday)
            {
                WorkingHours wh = new WorkingHours();
                wh.MuseumId = model.MuseumId;
                wh.OpenTime = model.startTime;
                wh.CloseTime = model.endTime;
                wh.Day = 7;
                if (workingHours.Where(x => x.Day == 7).Count() != 0)
                    workinghourRepository.UpdateHours(wh);
                else
                    workinghourRepository.InsertHours(wh);
            }

            workinghourRepository.Save();

            return RedirectToAction("GetMuseum", "Museum", new { id = model.MuseumId });
        }
    }
}