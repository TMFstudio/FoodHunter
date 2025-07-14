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

        public static IEnumerable<CategoryViewModel> ToViewModelList(this IEnumerable<Category> category)
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
                CreateDate = product.CreateDate,
                ProductTypeName = product.ProductType.Name,
                ProductTypeId = product.ProductTypeId,
                DisplayOrder = product.DisplayOrder,
            };
        }

        public static IEnumerable<ProductViewModel> ToViewModelList(this IEnumerable<Product> products)
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
                CreateDate = product.CreateDate,
                ProductTypeId = product.ProductTypeId,
                DisplayOrder = product.DisplayOrder
            };
        }

        #endregion

        #region ProductType
        public static ProductTypeViewModel ToViewModel(this ProductType productType)
        {
            return new ProductTypeViewModel
            {
                Id = productType.Id,
                Name = productType.Name,
            };
        }

        public static IEnumerable<ProductTypeViewModel> ToViewModelList(this IEnumerable<ProductType> productTypes)
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

        #region ProductCategory

        public static ProductCategoryViewModel ToViewModel(this ProductCategory  productCategory)
        {
            return new ProductCategoryViewModel
            {
                Id = productCategory.Id,
                Product = productCategory.Product,
                Category = productCategory.Category,
                CategoryId = productCategory.CategoryId,
                ProductId = productCategory.ProductId,
            };
        }
        public static IEnumerable<ProductCategoryViewModel> ToViewModelList(this IEnumerable<ProductCategory> productCategory)
        {
            return productCategory.Select(x => x.ToViewModel()).ToList();
        }
        public static ProductCategory ToEntity(this ProductCategoryViewModel productCategory)
        {
            return new ProductCategory
            {
                Id = productCategory.Id,
                Product = productCategory.Product,
                Category = productCategory.Category,
                CategoryId = productCategory.CategoryId,
                ProductId = productCategory.ProductId,
            };
        }


        #endregion
    }
}
