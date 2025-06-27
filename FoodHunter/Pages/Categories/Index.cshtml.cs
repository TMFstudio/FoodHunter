using Data;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FoodHunter.ViewModel;
using FoodHunter.Mapper;

namespace FoodHunter.Pages.Categories
{
    public class IndexModel : PageModel
    {
        public ApplicationDbContext _dbContext { get; set; }
        public IEnumerable<CategoryViewModel> categories { get; set; }
        public IndexModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void OnGet()
        {
            categories = _dbContext.Category.ToViewModelList();
        }
    }
}
