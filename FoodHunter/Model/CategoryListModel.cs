namespace FoodHunter.Model
{
    public partial record CategoryListModel : BasePageModel
    {
        public CategoryListModel()
        {
            categoryModels = new List<CategoryModel>();
        }
        public List<CategoryModel> categoryModels  { get; set; }
    }
}
