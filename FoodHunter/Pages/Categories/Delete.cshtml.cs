using Data;
using FoodHunter.Mapper;
using FoodHunter.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodHunter.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryViewModel category { get; set; }
        public DeleteModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id != 0)
            {
                var entity = await _dbContext.Category.FindAsync(id);
                _dbContext.Category.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return Page();
            }
            return Page();
        }
    }
}
