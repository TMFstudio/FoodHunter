
using Core.Models;


namespace Service.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task DeleteCategoryByIdAsync(int id);
        Task InsertCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);

    }
}
