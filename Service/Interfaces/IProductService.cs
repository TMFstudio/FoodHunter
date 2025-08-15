using Core;
using Core.Models;


namespace Service.Interfaces
{
    public interface IProductService
    {
        Task<IPagedList<Product>> GetAllProductsAsync(int pageIndex=0,int pageSize= int.MaxValue);
        Task<Product> GetProductByIdAsync(int id);
        Task DeleteProductByIdAsync(int id);
        Task InsertProductAsync(Product product);
        Task UpdateProductAsync(Product product);
    }
}
