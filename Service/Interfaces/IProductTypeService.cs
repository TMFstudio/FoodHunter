

using Core.Models;

namespace Service.Interfaces
{
    public interface IProductTypeService
    {
        Task<IEnumerable<ProductType>> GetAllProductTypesAsync();
        Task<ProductType> GetProductTypeByIdAsync(int id);
        Task DeleteProductTypeByIdAsync(int id);
        Task InsertProductTypeAsync(ProductType productType);
        Task UpdateProductTypeAsync(ProductType productType);
    }
}
