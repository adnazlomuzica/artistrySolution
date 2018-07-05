using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using artistry_Data.Context;
using artistry_Data.DAL;
using artistry_Data.Models;
using artistry_Web.Helper;
using artistry_Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace artistry_Web.Controllers
{
    [ServiceFilter(typeof(LogFilter))]
    public class AutentificationController : Controller
    {
        private readonly IUserRepository userRepository;
        private ILogger<AutentificationController> _logger;

        public AutentificationController(Context context, ILogger<AutentificationController> logger)
        {
            this.userRepository = new UserRepository(context);
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new LoginVM()
            {
                RememberPassword = true
            });
        }

        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginVM login)
        {
            UserAccounts u = userRepository.GetUser(login.Username);

            string password;

            if (u == null)
            {
                TempData["Error"] = "You have entered an invalid username or password!";
                return RedirectToAction("Index", "Autentification");
            }

            password = GeneratePassword.GenerateHash(login.Password, u.PasswordSalt);

            u = userRepository.GetUser(login.Username, password);

            if (u == null)
            {
                TempData["Error"] = "You have entered an invalid username or password!";
                return RedirectToAction("Index", "Autentification", login);
            }

            HttpContext.SetLoggedUser(u, login.RememberPassword);

            return RedirectToAction("Index", "Home", new { area=""});
        }

        public IActionResult Logout()
        {
            HttpContext.SetLoggedUser(null);
            return RedirectToAction("Index", "Home");
        }
    }
}