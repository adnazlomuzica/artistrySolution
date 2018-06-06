using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.Models
{
    public class Messages
    {
        public int Id { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }

        [Required(ErrorMessage = "Please enter your message")]
        public string Text { get; set; }
        public bool Seen { get; set; }
        public DateTime Date { get; set; }
        public virtual UserAccounts Sender { get; set; }
        public virtual UserAccounts Receiver { get; set; }
    }
}
