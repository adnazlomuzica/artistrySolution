using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Web.Areas.Administrator.ViewModels
{
    public class MessageVM
    {
        public List<Messages> Messages { get; set; }
        public Messages Reply { get; set; }
        public int ReceiverId { get; set; }
        public int SenderId { get; set; }
    }
}
