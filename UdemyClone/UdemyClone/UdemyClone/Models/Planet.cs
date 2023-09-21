using System.Collections.Generic;

namespace UdemyClone.Models
{
    public class Planet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public List<Satelite>Satelite { get; set; }
    }
}
