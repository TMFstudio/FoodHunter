using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodHunter.Model
{
    public record MenuItemsModel:BasePageModel
    {
        public List<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
        public List<ProductModel> Products { get; set; } = new List<ProductModel>();
        public List<ProductTypeModel> ProductTypes { get; set; } = new List<ProductTypeModel>();
    }
}
