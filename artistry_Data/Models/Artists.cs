using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.Models
{
    public class Artists
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Born { get; set; }
        public int? Died { get; set; }
        public string Biography { get; set; }
        public int CountryId { get; set; }
        public virtual Countries Country { get; set; }

    }
}
