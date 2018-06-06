using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.Models
{
    public class ArtistMovements
    {
        public int Id { get; set; }
        public int StyleId { get; set; }
        public virtual Styles Style { get; set; }
        public int ArtistId { get; set; }
        public virtual Artists Artist { get; set; }
    }
}
