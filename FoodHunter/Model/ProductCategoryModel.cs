using Core.Models;

namespace FoodHunter.Model
{
    public record ProductCategoryModel : BaseModel
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
