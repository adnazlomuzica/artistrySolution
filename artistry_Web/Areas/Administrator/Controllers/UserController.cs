using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using artistry_Data.Context;
using artistry_Data.DAL;
using artistry_Data.Models;
using artistry_Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace artistry_Web.Areas.Administrator.Controllers
{
    [Authorization(true, false, false)]
    [Area("Administrator")]
    [Route("Administrator/[controller]")]
    public class UserController : Controller
    {
        private readonly IAdministratorRepository adminRepository;
        private readonly IUserRepository userRepository;

        public UserController(Context context)
        {
            this.adminRepository = new AdministratorRepository(context);
            this.userRepository = new UserRepository(context);
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Profile")]
        public IActionResult Profile()
        {
            UserAccounts model = Autentification.GetLoggedUser(HttpContext);
            Administrators a = adminRepository.GetAdministrator(model.Id);

            ViewData["Email"] = a.Email;

            return View("Index",a);
        }

        [HttpGet("GetUser")]
        public IActionResult GetUser()
        {
            UserAccounts model = Autentification.GetLoggedUser(HttpContext);
            Administrators a = adminRepository.GetAdministrator(model.Id);

            return PartialView("UserName", a.FirstName);
        }

        [HttpGet("UserInfo")]
        public IActionResult UserInfo()
        {
            UserAccounts model = Autentification.GetLoggedUser(HttpContext);
            Administrators a = adminRepository.GetAdministrator(model.Id);

            return PartialView("UserInfo", a);
        }

        [HttpPost("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Administrators admin)
        {
            if (!ModelState.IsValid)
            {              
               return View("Index", admin);
            }

            UserAccounts u= userRepository.GetUserById(admin.UserId);
            admin.User = u;
            adminRepository.UpdateAdmin(admin);
            adminRepository.Save();

            return RedirectToAction("Profile", "User");
        }

        [HttpPost("UserEdit")]
        [ValidateAntiForgeryToken]
        public IActionResult UserEdit(UserAccounts user)
        {
            if (!ModelState.IsValid)
            {
                Administrators a = adminRepository.GetAdministrator(user.Id);
                return View("Index", a);
            }

            if (user.PasswordHash != null && user.PasswordSalt != null)
            {
                if (user.PasswordHash == user.PasswordSalt)
                {
                    string password = user.PasswordHash;
                    user.PasswordSalt = GeneratePassword.GenerateSalt();
                    user.PasswordHash = GeneratePassword.GenerateHash(password, user.PasswordSalt);
                    userRepository.UpdateUser(user);
                    userRepository.Save();
                }
            }
 
            return RedirectToAction("Profile", "User");
        }
    }
}