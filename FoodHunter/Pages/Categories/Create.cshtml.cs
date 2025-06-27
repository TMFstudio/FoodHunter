using Core.Models;
using Data;
using FoodHunter.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodHunter.Pages.Categories
{
    public class CreateModel : PageModel
    {
        public ApplicationDbContext _dbContext { get; set; }
        public CategoryViewModel category { get; set; }
        public CreateModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task OnGet()
        {
            category = new CategoryViewModel();
        }
        public async Task<IActionResult> OnPost(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Add
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
