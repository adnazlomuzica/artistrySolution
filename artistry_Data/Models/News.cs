using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.Models
{
    public class News
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [Required(ErrorMessage ="Please enter title")]
        public string Title {get;set;}

        [Required(ErrorMessage = "Please enter subtitle")]
        public string SubTitle { get; set; }

        [Required(ErrorMessage = "Please enter text")]
        public string Text { get; set; }

        public int MuseumId { get; set; }
        public virtual Museums Museum { get; set; }
    }
}
