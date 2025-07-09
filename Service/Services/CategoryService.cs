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
            var entity = await _categoryRepository.GetByIdAsync(id);
            if (entity != null)
            {
                await _categoryRepository.RemoveAsync(entity);
            }

        }

        public virtual async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public virtual async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
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