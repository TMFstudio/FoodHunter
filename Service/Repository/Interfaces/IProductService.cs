using Core.Models;


namespace Service.Repository.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task DeleteProductByIdAsync(int id);
        Task InsertProductAsync(Product product);
        Task UpdateProductAsync(Product product);
    }
}
