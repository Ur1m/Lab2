using System;

namespace UdemyClone.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeamId { get; set; }
        public DateTime BirthDay { get; set; }
        public Team Team { get; set; }
    }
}
