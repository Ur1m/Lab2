using System.Collections.Generic;

namespace UdemyClone.DTO
{
    public class TeamDTO
    {
        public string Name { get; set; }
        public List<PlayerDto> Players{ get; set; }
    }
}
