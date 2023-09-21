using System.Collections.Generic;
using UdemyClone.Models;

namespace UdemyClone.DTO
{
    public class PlanetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public List<SateliteDto> Satelite { get; set; }
    }
}
