using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.Models
{
    public class Collections
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Please enter name")]
        public string Name { get; set; }
        public int MuseumId { get; set; }
        public virtual Museums Museum { get; set; }

        [Required(ErrorMessage = "Please enter description")]
        public string Description { get; set; }
        public bool Active { get; set; }
        public int ImageId { get; set; }
        public virtual Images Image { get; set; }
    }
}
