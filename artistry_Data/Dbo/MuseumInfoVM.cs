using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.Dbo
{
    public class MuseumInfoVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? ImageId { get; set; }
        public virtual Images Image { get; set; }
    }
}
