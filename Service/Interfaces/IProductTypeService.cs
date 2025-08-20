using Core;
using Core.Models;

namespace Service.Interfaces
{
    public interface IProductTypeService
    {
        Task<IPagedList<ProductType>> GetAllProductTypesAsync(int pageIndex = 0, int pageSize = int.MaxValue);
        Task<ProductType> GetProductTypeByIdAsync(int id);
        Task DeleteProductTypeByIdAsync(int id);
        Task InsertProductTypeAsync(ProductType productType);
        Task UpdateProductTypeAsync(ProductType productType);
    }
}
