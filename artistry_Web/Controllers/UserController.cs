using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using artistry_Data.Context;
using artistry_Data.DAL;
using artistry_Data.Models;
using artistry_Web.Helper;
using artistry_Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace artistry_Web.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IClientRepository clientRepository;

        public UserController(Context context)
        {
            this.userRepository = new UserRepository(context);
            this.clientRepository = new ClientRepository(context);
        }

        [HttpGet]
        public IActionResult Index()
        {
            UserVM model = new UserVM();
            return View(model);
        }

        [HttpPost]
        public IActionResult Register(UserVM model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            UserAccounts user = new UserAccounts();
            user.Active = true;
            user.RegistrationDate = DateTime.Now;
            user.Username = model.Username;
            user.PasswordSalt = GeneratePassword.GenerateSalt();
            user.PasswordHash = GeneratePassword.GenerateHash(model.Password, user.PasswordSalt);

            userRepository.InsertUser(user);
            userRepository.Save();

            Clients client = new Clients();
            client.Email = model.Email;
            client.FirstName = model.FirstName;
            client.LastName = model.LastName;
            client.UserId = user.Id;

            clientRepository.InsertClient(client);
            clientRepository.Save();

            return RedirectToAction("Index", "Autentification");
        }

    }
}