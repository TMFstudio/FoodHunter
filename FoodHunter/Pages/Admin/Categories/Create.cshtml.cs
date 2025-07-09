using Core.Models;
using Data;
using FoodHunter.Mapper;
using FoodHunter.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Repository.Interfaces;

namespace FoodHunter.Admin.Categories
{

    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ICategoryService _categoryService;
        public CategoryViewModel category { get; set; }
        public CreateModel(ICategoryService  categoryService)
        {
            _categoryService = categoryService;
        }
        public void OnGet()
        {
          
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var entity=category.ToEntity();
                await _categoryService.InsertCategoryAsync(entity);
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
