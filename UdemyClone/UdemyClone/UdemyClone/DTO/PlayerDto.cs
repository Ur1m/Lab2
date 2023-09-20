using System;

namespace UdemyClone.DTO
{
    public class PlayerDto
    {
        public string Name { get; set; }
        public int TeamId { get; set; }
        public DateTime BirthDay{ get; set; }
        public TeamDTO Team { get; set; }
    }
}
