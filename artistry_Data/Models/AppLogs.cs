using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.Models
{
    public class AppLogs
    {
        public const int MaximumExceptionLength = 2000;
        public const int MaximumMessageLength = 4000;

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Application { get; set; }

        [Required]
        [StringLength(50)]
        public string Level { get; set; }

        [Required]
        public DateTime Logged { get; set; }

        [Required]
        [StringLength(MaximumMessageLength)]
        public string Message { get; set; }

        [StringLength(255)]
        public string Logger { get; set; }

        [StringLength(MaximumMessageLength)]
        public string CallSite { get; set; }

        [StringLength(MaximumExceptionLength)]
        public String Exception { get; set; }

        public bool Seen { get; set; }
    }
}
