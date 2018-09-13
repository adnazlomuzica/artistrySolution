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
    public class MuseumController : Controller
    {
        private readonly IMuseumRepository museumRepository;
        private readonly IMuseumTypeRepository museumTypeRepository;
        private readonly IWorkingHourRepository workingHoursRepository;
        private readonly IImageRepository imageRepository;

        public MuseumController(Context context)
        {
            this.museumRepository = new MuseumRepository(context);
            this.museumTypeRepository = new MuseumTypeRepository(context);
            this.workingHoursRepository = new WorkingHourRepository(context);
            this.imageRepository = new ImageRepository(context);
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("GetName")]
        public IActionResult GetName()
        {
            UserAccounts model = Autentification.GetLoggedUser(HttpContext);
            Museums m = museumRepository.GetMuseumByAccId(model.Id);

            return PartialView("GetName", m.Name);
        }

        [HttpGet("GetInfo")]
        public IActionResult GetInfo()
        {
            UserAccounts model = Autentification.GetLoggedUser(HttpContext);
            Museums m = museumRepository.GetMuseumByAccId(model.Id);

            return PartialView("GetInfo", m);
        }

        [HttpGet("Details")]
        public IActionResult Details()
        {
            int userId = Autentification.GetLoggedUser(HttpContext).Id;
            Museums m = museumRepository.GetMuseumByAccId(userId);
            MuseumVM model = new MuseumVM()
            {
                Id = m.Id,
                Name = m.Name,
                UserId = m.UserId,
                Username = m.User.Username,
                PasswordHash = m.User.PasswordHash,
                PasswordSalt = m.User.PasswordSalt,
                RegistrationDate = m.User.RegistrationDate.ToString("dd/MM/yyyy"),
                MuseumType = m.MuseumType.Name,
                MuseumTypeId = m.MuseumTypeId,
                Year = m.OpeningYear,
                QrScanning = m.QrScanning,
                TicketSelling = m.OnlineTickets,
                Description = m.Description,
                Email = m.Email,
                Phone = m.Phone,
                Address = m.Address,
                Latitude = m.Latitude,
                Longitude = m.Longitude,
                Images = imageRepository.GetMuseumImages(m.Id),
                WorkingHour = workingHoursRepository.GetWorkingHours(m.Id),
                MuseumTypes = null
            };

            return View("Details", model);
        }

        [HttpGet("GetMuseum")]
        public IActionResult GetMuseum(int? id)
        {
            int userId = Autentification.GetLoggedUser(HttpContext).Id;
            Museums m = museumRepository.GetMuseumByAccId(userId);
            id = m.Id;
            MuseumVM model = new MuseumVM()
            {
                Id = m.Id,
                Name = m.Name,
                UserId = m.UserId,
                Username = m.User.Username,
                PasswordHash = m.User.PasswordHash,
                PasswordSalt = m.User.PasswordSalt,
                RegistrationDate = m.User.RegistrationDate.ToString("dd/MM/yyyy"),
                MuseumType = m.MuseumType.Name,
                MuseumTypeId = m.MuseumTypeId,
                Year = m.OpeningYear,
                QrScanning = m.QrScanning,
                TicketSelling = m.OnlineTickets,
                Description = m.Description,
                Email = m.Email,
                Phone = m.Phone,
                Address = m.Address,
                Latitude = m.Latitude,
                Longitude = m.Longitude,
                Images = imageRepository.GetMuseumImages(m.Id),
                WorkingHour = workingHoursRepository.GetWorkingHours(m.Id)
            };

            model.MuseumTypes = new SelectList(museumTypeRepository.GetMuseumTypes(), "Id", "Name");

            return View("Edit", model);
        }

        [HttpPost("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MuseumVM model)
        {
            if (!ModelState.IsValid)
            {
                model.MuseumTypes = new SelectList(museumTypeRepository.GetMuseumTypes(), "Id", "Name");
                return View("Edit", model);
            }

            Museums m = new Museums();
            m.Id = model.Id;
            m.Name = model.Name;
            m.UserId = model.UserId;
            m.Latitude = model.Latitude;
            m.Longitude = model.Longitude;
            m.Address = model.Address;
            m.Email = model.Email;
            m.Phone = model.Phone;
            m.MuseumTypeId = model.MuseumTypeId;
            m.Description = model.Description;
            m.OpeningYear = model.Year;
            m.QrScanning = model.QrScanning;
            m.OnlineTickets = model.TicketSelling;

            museumRepository.UpdateMuseum(m);
            museumRepository.Save();

            return RedirectToAction("Details", new { id=model.Id});
        }

    }
}