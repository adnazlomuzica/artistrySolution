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

namespace artistry_Web.Areas.Moderator.Controllers
{
    [Authorization(false, true, false)]
    [Area("Moderator")]
    [Route("Moderator/[controller]")]
    public class MessageController : Controller
    {
        private readonly IMessageRepository messageRepository;
        private readonly IUserRepository userRepository;
        public MessageController(Context context)
        {
            this.messageRepository = new MessageRepository(context);
            this.userRepository = new UserRepository(context);
        }

        [HttpGet("PartialIndex")]
        public PartialViewResult PartialIndex()
        {
            int userId = Autentification.GetLoggedUser(HttpContext).Id;
            IEnumerable<Messages> model = messageRepository.GetMessagesByUser(userId);

            ViewData["User"] = userId;

            return PartialView("PartialIndex", model);
        }

        [HttpGet("Add")]
        public PartialViewResult Add()
        {
            int userId = Autentification.GetLoggedUser(HttpContext).Id;

            IEnumerable<UserAccounts> users = userRepository.GetUsers(userId);

            ViewBag.ReceiverId = new SelectList(users, "Id", "Username");

            return PartialView("Add");
        }

        [HttpGet("Details")]
        public PartialViewResult Details(int id)
        {
            int userId = Autentification.GetLoggedUser(HttpContext).Id;
            IEnumerable<Messages> message = messageRepository.GetMessagesById(id, userId);

            MessageVM model = new MessageVM();
            model.Messages = new List<Messages>();
            foreach (Messages m in message)
            {
                if (m.ReceiverId == userId)
                {
                    m.Seen = true;
                    messageRepository.UpdateMessage(m);
                }

                model.Messages.Add(m);
            }

            messageRepository.Save();

            model.Reply = new Messages();
            Messages mess = message.Take(1).SingleOrDefault();
            int senderId = Convert.ToInt32(mess.SenderId);
            int receiverId = Convert.ToInt32(mess.ReceiverId);

            if (receiverId == userId)
            {
                model.ReceiverId = userId;
                model.SenderId = id;
            }
            else
            {
                model.ReceiverId = id;
                model.SenderId = userId;
            }

            ViewData["userId"] = userId;
            return PartialView("Details", model);
        }

        [HttpPost("Save")]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Messages m)
        {
            if (ModelState.IsValid)
            {
                Messages message = new Messages();
                message.Date = DateTime.Now;
                message.SenderId = Autentification.GetLoggedUser(HttpContext).Id;
                message.Seen = false;
                message.ReceiverId = m.ReceiverId;
                message.Text = m.Text;

                messageRepository.InsertMessage(message);
                messageRepository.Save();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost("Reply")]
        [ValidateAntiForgeryToken]
        public IActionResult Reply(MessageVM m)
        {
            if (ModelState.IsValid)
            {
                Messages message = new Messages();
                message.Date = DateTime.Now;
                message.SenderId = Autentification.GetLoggedUser(HttpContext).Id;
                message.Seen = false;
                message.ReceiverId = m.SenderId;
                message.Text = m.Reply.Text;

                messageRepository.InsertMessage(message);
                messageRepository.Save();
            }

            return RedirectToAction("Index", "Home");
        }

        //Get
        [HttpGet("NewMessages")]
        public IActionResult NewMessages()
        {
            int id = Autentification.GetLoggedUser(HttpContext).Id;

            int newMessages = messageRepository.GetNewMessages(id);

            return PartialView("NewMessages", newMessages.ToString());
        }
    }
}