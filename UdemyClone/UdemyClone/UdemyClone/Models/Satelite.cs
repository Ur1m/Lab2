using System.Collections.Generic;

namespace UdemyClone.Models
{
    public class Satelite
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int PlanetId { get; set; }
        public Planet Planet { get; set; }

    }
}
