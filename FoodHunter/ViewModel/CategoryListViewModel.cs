namespace FoodHunter.ViewModel
{
    public partial class CategoryListViewModel
    {
        public CategoryListViewModel()
        {
            CategoryList = new List<CategoryViewModel>();
        }
        public List<CategoryViewModel> CategoryList { get; set; }
    }
}
