
using Core.Models;

namespace Service.Interfaces
{
    public interface IProductsCategoriesService
    {
        Task<IEnumerable<ProductCategory>> GetAllProductsCategoriesAsync();
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<IEnumerable<Product>> GetAllProductAsync();
        Task<ProductCategory> GetProductCategoryAsync(int id,int? categoryId=0,int? ProductId=0);
        Task DeleteProductCategoryByIdAsync(int id);
        Task InsertProductCategoryAsync(ProductCategory product);
        Task UpdateProductCategoryAsync(ProductCategory product);
        Task<bool> CheckProductCategoryExistenceAsync(int categoryId, int ProductId);

    }
}
