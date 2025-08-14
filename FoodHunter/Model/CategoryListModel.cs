namespace FoodHunter.Model
{
    public partial record CategoryListModel : BasePageModel
    {
        public CategoryListModel()
        {
            categoryModels = new List<CategoryModel>();
        }
        public IEnumerable<CategoryModel> categoryModels  { get; set; } = new List<CategoryModel>();
    }
}
