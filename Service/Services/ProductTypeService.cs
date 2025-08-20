

using Core;
using Core.Models;
using Data.Repository;
using Service.Interfaces;

namespace Service.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IRepository<ProductType> _productTypeRepository;
        public ProductTypeService(IRepository<ProductType> productRepository)
        {
            _productTypeRepository = productRepository;
        }

        public virtual async Task<IPagedList<ProductType>> GetAllProductTypesAsync(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return await _productTypeRepository.GetAllPagedAsync(async query =>
            {
                query.OrderByDescending(x => x.Id);
                return query;

            }, pageIndex, pageSize);
        }
        public virtual async Task DeleteProductTypeByIdAsync(int id)
        {
            var entity = await _productTypeRepository.GetByIdAsync(id);
            if (entity != null)
            {
                await _productTypeRepository.RemoveAsync(entity);
            }
        }
        public virtual async Task<ProductType> GetProductTypeByIdAsync(int id)
        {
            return await _productTypeRepository.GetByIdAsync(id);
        }

        public virtual async Task InsertProductTypeAsync(ProductType productType)
        {
             await _productTypeRepository.InsertAsync(productType);
        }

        public virtual async Task UpdateProductTypeAsync(ProductType productType)
        {
             await _productTypeRepository.UpdateAsync(productType);
        }
    }
}
