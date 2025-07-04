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
        private readonly ApplicationDbContext _dbContext;
        public IEnumerable<CategoryViewModel> categories { get; set; }
        public IndexModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task OnGet()
        {
            categories = _dbContext.Category.ToViewModelList();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id != 0)
            {
                var entity = await _dbContext.Category.FindAsync(id);
                _dbContext.Category.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return RedirectToPage();
            }
            return RedirectToPage();
        }
    }
}
