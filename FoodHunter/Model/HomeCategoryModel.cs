namespace FoodHunter.Model
{
    public record HomePageCategoryModel:BasePageModel
    {
        public HomePageCategoryModel()
        {
            
        }
        public List<ProductModel> Products { get; set; }=new List<ProductModel>();
        public List<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
        public string? CategoryName { get; set; }
    }
}
