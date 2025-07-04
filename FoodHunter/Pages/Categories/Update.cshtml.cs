using Data;
using FoodHunter.Mapper;
using FoodHunter.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FoodHunter.Pages.Categories
{
    [BindProperties]
    public class UpdateModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryViewModel category { get; set; }

        public UpdateModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> OnGet(int id)
        {
            if (id != 0 && id != null)
            {
                var entity = await _dbContext.Category.FindAsync(id);
                category = entity.ToViewModel();
                return Page();
            }
            return RedirectToPage("Categories/Index");
        }
        public async Task<IActionResult> OnPost(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = category.ToEntity();
                _dbContext.Update(entity);
                await _dbContext.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
