using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.Models
{
    public class Events
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter start time")]
        [DataType(DataType.Date, ErrorMessage ="Date is not in right format")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage ="Please enter end time")]
        [DataType(DataType.Date, ErrorMessage = "Date is not in right format")]
        public DateTime EndTime { get; set; }

        [Required(ErrorMessage ="Please enter title")]
        public string Title { get; set; }
        public string Description { get; set; }
        public int MuseumId { get; set; }
        public virtual Museums Museum { get; set; }
    }
}
