using Core.Models;
using FoodHunter.Model;

namespace FoodHunter.Mapper
{
    public static class Mapper
    {
        #region Category
        public static CategoryModel ToModel(this Category category)
        {
            return new CategoryModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                DisplayOrder = category.DisplayOrder
            };
        }

        public static IEnumerable<CategoryModel> ToModelList(this IEnumerable<Category> category)
        {
           return category.Select(x=>x.ToModel()).ToList();
        }
        public static Category ToEntity(this CategoryModel category)
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

        public static ProductModel ToModel(this Product  product)
        {
            return new ProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                CreateDate = product.CreateDate,
                ProductTypeName = product.ProductType.Name,
                Price = product.Price,
                Image = product.Image,
                ProductTypeId = product.ProductTypeId,
                DisplayOrder = product.DisplayOrder,
            };
        }

        public static IEnumerable<ProductModel> ToModelList(this IEnumerable<Product> products)
        {
            return products.Select(x => x.ToModel()).ToList();
        }
        public static Product ToEntity(this ProductModel  product)
        {
            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                CreateDate = product.CreateDate,
                ProductTypeId = product.ProductTypeId,
                Image = product.Image,
                Price = product.Price,
                DisplayOrder = product.DisplayOrder
            };
        }

        #endregion

        #region ProductType
        public static ProductTypeModel ToModel(this ProductType productType)
        {
            return new ProductTypeModel
            {
                Id = productType.Id,
                Name = productType.Name,
            };
        }

        public static IEnumerable<ProductTypeModel> ToModelList(this IEnumerable<ProductType> productTypes)
        {
            return productTypes.Select(x => x.ToModel()).ToList();
        }
        public static ProductType ToEntity(this ProductTypeModel productType)
        {
            return new ProductType
            {
                Id = productType.Id,
                Name = productType.Name,
            };
        }

        #endregion

        #region ProductCategory

        public static ProductCategoryModel ToModel(this ProductCategory  productCategory)
        {
            return new ProductCategoryModel
            {
                Id = productCategory.Id,
                Product = productCategory.Product,
                Category = productCategory.Category,
                CategoryId = productCategory.CategoryId,
                ProductId = productCategory.ProductId,
            };
        }
        public static IEnumerable<ProductCategoryModel> ToModelList(this IEnumerable<ProductCategory> productCategory)
        {
            return productCategory.Select(x => x.ToModel()).ToList();
        }
        public static ProductCategory ToEntity(this ProductCategoryModel productCategory)
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
