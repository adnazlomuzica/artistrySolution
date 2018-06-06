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
    public class AppLogController : Controller
    {
        private readonly IAppLogRepository appLogRepository;
        public AppLogController(Context context)
        {
            this.appLogRepository = new AppLogRepository(context);
        }

        //Get
        [HttpGet("Index")]
        public IActionResult Index()
        {
            IEnumerable<AppLogs> model = appLogRepository.GetAppLogs();

            return View(model);
        }

        //Get
        [HttpGet("PartialIndex")]
        public IActionResult PartialIndex()
        {
            IEnumerable<AppLogs> model = appLogRepository.GetLastLogs();

            try
            {
                foreach (AppLogs item in model)
                {
                    if (item.Seen == false)
                    {
                        item.Seen = true;
                        appLogRepository.UpdateAppLogs(item);
                    }
                }

                appLogRepository.Save();
            }
            catch(Exception ex)
            {

            }
            return PartialView("PartialIndex",model.OrderByDescending(x=>x.Logged));
        }

        //Get
        [HttpGet("NewLogs")]
        public IActionResult NewLogs()
        {
            int newLogs = appLogRepository.GetNewLogs();
            
            return PartialView("NewLogs", newLogs.ToString());
        }

    }
}