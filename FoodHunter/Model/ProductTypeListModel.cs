namespace FoodHunter.Model
{
    public record ProductTypeListModel: BasePageModel
    {
        public ProductTypeListModel()
        {
            ProductTypeModels = new List<ProductTypeModel>();
        }
        public List<ProductTypeModel> ProductTypeModels { get; set; }
    }
}
