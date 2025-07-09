
using Core.Models;
using Data.Repository;
using Service.Repository.Services;

namespace Service.Repository.Interfaces
{
    public interface ICategoryService 
    {
        IEnumerable<Category> GetCategories();
    }
}
