
using FoodHunter.Mapper;
using FoodHunter.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interfaces;

namespace FoodHunter.Admin.Categories
{

    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ICategoryService _categoryService;
        public CategoryViewModel Category { get; set; } = default!;
        public CreateModel(ICategoryService  categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var entity=Category.ToEntity();
                await _categoryService.InsertCategoryAsync(entity);
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
