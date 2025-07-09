using Core.Models;
using Data.Repository;
using Service.Interfaces;

namespace Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public virtual async Task DeleteProductByIdAsync(int id)
        {
            var entity = await _productRepository.GetByIdAsync(id);
            if (entity != null)
            {
                await _productRepository.RemoveAsync(entity);
            }

        }

        public virtual async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public virtual async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public virtual async Task InsertProductAsync(Product product)
        {
            await _productRepository.InsertAsync(product);
        }

        public virtual async Task UpdateProductAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
        }
    }
}
