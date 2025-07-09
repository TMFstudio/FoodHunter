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

        public static ProductViewModel ToViewModel(this Product  product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ProductsCategory = product.ProductsCategory,
                ProductTypeId = product.ProductTypeId,
                ProductType = product.ProductType,
                DisplayOrder = product.DisplayOrder
            };
        }

        public static List<ProductViewModel> ToViewModelList(this IEnumerable<Product> products)
        {
            return products.Select(x => x.ToViewModel()).ToList();
        }
        public static Product ToEntity(this ProductViewModel  product)
        {
            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ProductsCategory = product.ProductsCategory,
                ProductTypeId = product.ProductTypeId,
                ProductType = product.ProductType,
                DisplayOrder = product.DisplayOrder
            };
        }

        #endregion

        #region ProductType
        public static ProductTypeViewModel ToViewModel(this ProductType category)
        {
            return new ProductTypeViewModel
            {
                Id = category.Id,
                Name = category.Name,
            };
        }

        public static List<ProductTypeViewModel> ToViewModelList(this IEnumerable<ProductType> productTypes)
        {
            return productTypes.Select(x => x.ToViewModel()).ToList();
        }
        public static ProductType ToEntity(this ProductTypeViewModel productType)
        {
            return new ProductType
            {
                Id = productType.Id,
                Name = productType.Name,
            };
        }

        #endregion
    }
}
