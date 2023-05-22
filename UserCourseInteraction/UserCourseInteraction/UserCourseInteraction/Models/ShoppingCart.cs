using System.ComponentModel.DataAnnotations;

namespace UserCourseInteraction.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        public string userId { get; set; }
        public int ProductId { get; set; }

    }
}
