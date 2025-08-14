
using Core;
using Core.Models;


namespace Service.Interfaces
{
    public interface ICategoryService
    {
        Task<IPagedList<Category>> GetCategoriesAsync(int pageIndex = 0, int pageSize = 0);
        Task<Category> GetCategoryByIdAsync(int id);
        Task DeleteCategoryByIdAsync(int id);
        Task InsertCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);

    }
}
