using Core.Models;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;

namespace Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductType> _productTypeRepository;
        private readonly IRepository<Category> _CategoryRepository;
        public ProductService(IRepository<Product> productRepository,
          IRepository<ProductType> productTypeRepository,
          IRepository<Category> categoryRepository)
        {
            _productRepository = productRepository;
            _productTypeRepository = productTypeRepository;
            _CategoryRepository = categoryRepository;

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
            var query = _productRepository.Table.Include(x => x.ProductType).Include(x => x.ProductCategory);
            return await query.ToListAsync();
        }

        public virtual async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.Table
            .Include(x => x.ProductType)
            .FirstOrDefaultAsync(x => x.Id == id);
                 if (product == null)
                    return null;

            return product;
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
