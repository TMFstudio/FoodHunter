namespace FoodHunter.Model
{
    public record HomeModel : BaseModel
    {
        public HomeModel() 
        {
        }
        public List<CategoryModel> Categories { get; set; }=new List<CategoryModel>();
        public List<ProductModel> Products { get; set; } = new List<ProductModel>();
        public List<ProductTypeModel> ProductTypes { get; set; } = new List<ProductTypeModel>();


    }
}
