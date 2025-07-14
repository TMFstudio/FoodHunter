using Core.Models;

namespace FoodHunter.ViewModel
{
    public record ProductCategoryViewModel : BaseViewModel
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
