using Core.Models;
using Data.Repository;
using Service.Repository.Interfaces;

namespace Service.Repository.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        public CategoryService(IRepository<Category> categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }
        public IEnumerable<Category> GetCategories()
        {
        return   _categoryRepository.GetAll();
        }
    }
}