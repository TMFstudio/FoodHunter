using Core.Models;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;

namespace Service.Services
{
    public class ProductsCategoriesService : IProductsCategoriesService
    {
        private readonly IRepository<ProductCategory> _ProductCategoryRepository;
        public ProductsCategoriesService(IRepository<ProductCategory> ProductCategoryRepository)
        {
            _ProductCategoryRepository = ProductCategoryRepository;
        }

        public async Task DeleteProductCategoryByIdAsync(int id)
        {
            var entity = await _ProductCategoryRepository.GetByIdAsync(id);
            if (entity != null)
            {
                await _ProductCategoryRepository.RemoveAsync(entity);
            }
        }

        public Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllProductAsync()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<ProductCategory>> GetAllProductsCategoriesAsync()
        {
            var entity=  _ProductCategoryRepository.Table.Include(x => x.Category)
                .Include(x => x.Product);
            return await entity.ToListAsync();
        }

        public virtual async Task<ProductCategory> GetProductCategoryByIdAsync(int id)
        {
            return await _ProductCategoryRepository.GetByIdAsync(id);
        }

        public virtual async Task InsertProductCategoryAsync(ProductCategory product)
        {
             await _ProductCategoryRepository.InsertAsync(product);
        }

        public virtual async Task UpdateProductCategoryAsync(ProductCategory product)
        {
             await _ProductCategoryRepository.UpdateAsync(product);
        }
    }
}
