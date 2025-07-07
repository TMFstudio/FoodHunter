using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FoodHunter.ViewModel;
using FoodHunter.Mapper;

namespace FoodHunter.Admin.Categories
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
            categories = _dbContext.Categories.ToViewModelList();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id != 0)
            {
                var entity = await _dbContext.Categories.FindAsync(id);
                _dbContext.Categories.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return RedirectToPage();
            }
            return RedirectToPage();
        }
    }
}
