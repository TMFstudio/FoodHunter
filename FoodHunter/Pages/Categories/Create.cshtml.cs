using Core.Models;
using Data;
using FoodHunter.Mapper;
using FoodHunter.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodHunter.Pages.Categories
{

    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryViewModel category { get; set; }
        public CreateModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void OnGet()
        {
          
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var entity=category.ToEntity();
                await _dbContext.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
