using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using artistry_Data.Context;
using artistry_Data.DAL;
using artistry_Data.Models;
using artistry_Web.Areas.Administrator.ViewModels;
using artistry_Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace artistry_Web.Areas.Administrator.Controllers
{
    [Authorization(true, false, false)]
    [Area("Administrator")]
    [Route("Administrator/[controller]")]
    public class MuseumController : Controller
    {
        private readonly IMuseumRepository museumRepository;
        private readonly IMuseumTypeRepository museumtypeRepository;
        private readonly IUserRepository userRepository;

        public MuseumController(Context context)
        {
            this.museumRepository = new MuseumRepository(context);
            this.museumtypeRepository = new MuseumTypeRepository(context);
            this.userRepository = new UserRepository(context);
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            IEnumerable<Museums> model = museumRepository.GetMuseums();
            return View(model);
        }

        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            Museums model = museumRepository.GetMuseum(id);
            return View("Details", model);
        }

        [HttpGet]
        public IActionResult GetMuseum(int id)
        {
            Museums m = museumRepository.GetMuseum(id);
            MuseumVM model = new MuseumVM()
            {
                Id = m.Id,
                Name = m.Name,
                MuseumTypeId = m.MuseumTypeId,
                UserId = m.UserId,
                Username = m.User.Username,
                PasswordHash = m.User.PasswordHash,
                PasswordSalt = m.User.PasswordSalt,
                NewPassword = null,
                RepeatPassword = null,
                MuseumType = museumtypeRepository.GetMuseumTypes().Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList()
            };

            return View("Edit", model);
        }

        [HttpGet("Add")]
        public IActionResult Add()
        {
            MuseumVM m = new MuseumVM();

            m.MuseumType = new SelectList(museumtypeRepository.GetMuseumTypes(), "Id", "Name").ToList();

            return View(m);
        }

        [HttpPost("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MuseumVM museum)
        {
            if (!ModelState.IsValid)
            {
                museum.MuseumType = new SelectList(museumtypeRepository.GetMuseumTypes(), "Id", "Name").ToList();
                return View("Edit", museum);
            }

            UserAccounts u = userRepository.GetUserById(museum.UserId);
            if (museum.PasswordHash != null && museum.PasswordSalt != null)
            {
                if (museum.NewPassword == museum.RepeatPassword)
                {
                    if (museum.NewPassword != null && museum.RepeatPassword != null)
                    {
                        string password = museum.NewPassword;
                        u.PasswordSalt = GeneratePassword.GenerateSalt();
                        u.PasswordHash = GeneratePassword.GenerateHash(password, u.PasswordSalt);
                    }
                    else
                    {
                        u.PasswordHash = museum.PasswordHash;
                        u.PasswordSalt = museum.PasswordSalt;
                    }
                    u.Username = museum.Username;
                    userRepository.UpdateUser(u);
                    museumRepository.Save();

                    Museums m = museumRepository.GetMuseum(museum.Id);
                    m.MuseumTypeId = museum.MuseumTypeId;
                    m.Name = museum.Name;
                    m.UserId = u.Id;

                    museumRepository.UpdateMuseum(m);
                    museumRepository.Save();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost("Save")]
        [ValidateAntiForgeryToken]
        public IActionResult Save(MuseumVM museum)
        {
            if (!ModelState.IsValid)
            {
                museum.MuseumType = new SelectList(museumtypeRepository.GetMuseumTypes(), "Id", "Name").ToList();
                return View("Add", museum);
            }

            UserAccounts u = new UserAccounts();

            if (museum.PasswordHash == museum.PasswordSalt)
            {
                string password = museum.PasswordHash;
                u.PasswordSalt = GeneratePassword.GenerateSalt();
                u.PasswordHash = GeneratePassword.GenerateHash(password, u.PasswordSalt);
                u.Username = museum.Username;
                u.RegistrationDate = DateTime.Now;
                u.Active = true;

                userRepository.InsertUser(u);
                museumRepository.Save();

                Museums m = new Museums();
                m.MuseumTypeId = museum.MuseumTypeId;
                m.Name = museum.Name;
                m.UserId = u.Id;

                museumRepository.InsertMuseum(m);
                museumRepository.Save();
            }
            return RedirectToAction("Index");
        }

        [HttpGet("Deactivate")]
        public IActionResult Deactivate(int museumId)
        {
            Museums museum = museumRepository.GetMuseum(museumId);
            museum.User.Active = false;
            museumRepository.UpdateMuseum(museum);
            museumRepository.Save();

            return RedirectToAction("Index");
        }

        [HttpGet("Activate")]
        public IActionResult Activate(int museumId)
        {
            Museums museum = museumRepository.GetMuseum(museumId);
            museum.User.Active = true;
            museumRepository.UpdateMuseum(museum);
            museumRepository.Save();

            return RedirectToAction("Index");
        }

        [HttpGet("Search")]
        public IActionResult Search(string search)
        {
            List<Museums> model = new List<Museums>();
            if (search != null)
            {
                model = museumRepository.Search(search);
            }
            else
            {
                model = museumRepository.GetMuseums();
            }
            return View("Index", model);
        }

    }
}