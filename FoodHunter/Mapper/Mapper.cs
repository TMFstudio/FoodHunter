using Core.Models;
using FoodHunter.ViewModel;

namespace FoodHunter.Mapper
{
    public static class Mapper
    {
        #region Category
        public static CategoryViewModel ToViewModel(this Category category)
        {
            return new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                DisplayOrder = category.DisplayOrder
            };
        }

        public static List<CategoryViewModel> ToViewModelList(this IEnumerable<Category> category)
        {
           return category.Select(x=>x.ToViewModel()).ToList();
        }
        public static Category ToEntity(this CategoryViewModel category)
        {
            return new Category
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                DisplayOrder = category.DisplayOrder
            };
        }
        #endregion

        #region Product

        public static ProductViewModel ToViewModel(this Product category)
        {
            return new ProductViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                ProductsCategory = category.ProductsCategory,
                ProductTypeId = category.ProductTypeId,
                ProductType = category.ProductType,
                DisplayOrder = category.DisplayOrder
            };
        }

        public static List<ProductViewModel> ToViewModelList(this IEnumerable<Product> category)
        {
            return category.Select(x => x.ToViewModel()).ToList();
        }
        public static Product ToEntity(this ProductViewModel category)
        {
            return new Product
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                ProductsCategory = category.ProductsCategory,
                ProductTypeId = category.ProductTypeId,
                ProductType = category.ProductType,
                DisplayOrder = category.DisplayOrder
            };
        }

        #endregion
    }
}
