
using Core.Models;

namespace Service.Interfaces
{
    public interface IProductsCategoriesService
    {
        Task<IEnumerable<ProductCategory>> GetAllProductsCategoriesAsync();
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<IEnumerable<Product>> GetAllProductAsync();
        Task<ProductCategory> GetProductCategoryByIdAsync(int id);
        Task DeleteProductCategoryByIdAsync(int id);
        Task InsertProductCategoryAsync(ProductCategory product);
        Task UpdateProductCategoryAsync(ProductCategory product);
    }
}
