
using Core;
using Core.Models;


namespace Service.Interfaces
{
    public interface ICategoryService
    {
        Task<IPagedList<Category>> GetAllCategoriesAsync(int pageIndex =0, int pageSize = int.MaxValue);
        Task<Category> GetCategoryByIdAsync(int id);
        Task DeleteCategoryByIdAsync(int id);
        Task InsertCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);

    }
}
