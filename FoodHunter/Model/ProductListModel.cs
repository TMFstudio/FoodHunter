namespace FoodHunter.Model
{
    public record ProductListModel : BasePageModel
    {
        public ProductListModel()
        {
            ProductModels = new List<ProductModel>();
        }
        public List<ProductModel> ProductModels { get; set; } 
    }
}
