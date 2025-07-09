

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

        public virtual async Task<IEnumerable<ProductType>> GetAllProductTypesAsync()
        {
            return await _productTypeRepository.GetAllAsync();
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
