using UdemyClone.Models;

namespace UdemyClone.DTO
{
    public class SateliteDto
    {
        public bool IsDeleted { get; set; }
        public int PlanetId { get; set; }
        public PlanetDto Planet { get; set; }
    }
}
