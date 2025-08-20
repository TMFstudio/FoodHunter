namespace FoodHunter.Model
{
        public record ProductCategoryListModel : BasePageModel
        {
            public ProductCategoryListModel()
            {
            ProductsCategoriesModels = new List<ProductCategoryModel>();
            }
            public List<ProductCategoryModel> ProductsCategoriesModels { get; set; }
        }
    }

