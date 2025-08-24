using Core;
using Core.Models;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;

namespace Service.Services
{
    public class ProductsCategoriesService : IProductsCategoriesService
    {
        private readonly IRepository<ProductCategory> _ProductCategoryRepository;
        private readonly IRepository<Product> _ProductRepository;
        private readonly IRepository<Category> _CategoryRepository;
        public ProductsCategoriesService(IRepository<ProductCategory> ProductCategoryRepository, IRepository<Product> ProductRepository,
          IRepository<Category> CategoryRepository)
        {
            _ProductCategoryRepository = ProductCategoryRepository;
            _ProductRepository = ProductRepository;
            _CategoryRepository = CategoryRepository;
        }

        public async Task DeleteProductCategoryByIdAsync(int id)
        {
            var entity = await _ProductCategoryRepository.GetByIdAsync(id);
            if (entity != null)
            {
                await _ProductCategoryRepository.RemoveAsync(entity);
            }
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _CategoryRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {
            return await _ProductRepository.GetAllAsync();
        }

        public virtual async Task<IPagedList<ProductCategory>> GetAllProductsCategoriesAsync(int? productId=0,int? categoryId = 0,
          int pageIndex = 0,   int pageSize = int.MaxValue)
        {
            return await _ProductCategoryRepository.GetAllPagedAsync(async query =>
            {
                //bring categories with productids
                if (productId != 0)
                    query = query.Where(x => x.ProductId == productId).Include(x => x.Category);

                //bring categories with categoryids
                if (categoryId != 0)
                    query = query.Where(x => x.CategoryId == categoryId).Include(x => x.Product);
          
                query.OrderByDescending(x => x.Id);

                return query;

            }, pageIndex, pageSize);

        }

        public virtual async Task<ProductCategory> GetProductCategoryAsync(int id)
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
        public virtual async Task<bool> CheckProductCategoryExistenceAsync(int categoryId, int productId)
        {
            var query =  _ProductCategoryRepository.Table;
            return await query.AnyAsync(x => x.CategoryId == categoryId && x.ProductId == productId); 
        }
    }
}
