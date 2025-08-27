using Core;
using Core.Models;
using Data.Repository;
using Service.Interfaces;

namespace Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public virtual async Task DeleteCategoryByIdAsync(int id)
        {
            var entity = await _categoryRepository.GetByIdAsync(id:id);
            if (entity != null)
            {
                await _categoryRepository.RemoveAsync(entity);
            }

        }

        public virtual async Task<IPagedList<Category>> GetAllCategoriesAsync(int pageIndex = 0, int pageSize= int.MaxValue)
        {
            return await _categoryRepository.GetAllPagedAsync(async query =>
            {
                query = query.OrderByDescending(x => x.DisplayOrder);
                return query;
            }, pageIndex ,  pageSize : pageSize);
        }

        public virtual async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id: id);
        }

        public virtual async Task InsertCategoryAsync(Category category)
        {
            await _categoryRepository.InsertAsync(category);
        }

        public virtual async Task UpdateCategoryAsync(Category category)
        {
            await _categoryRepository.UpdateAsync(category);
        }
    }
}