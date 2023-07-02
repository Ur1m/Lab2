using UserCourseInteraction.Models;

namespace UserCourseInteraction.ViewModels
{
    public class ShoppingCartViewModel
    {
        public int Id { get; set; }
        public string userId { get; set; }
        public int ProductId { get; set; }
        public ProductDto ProductDto { get; set; }
    }
}
