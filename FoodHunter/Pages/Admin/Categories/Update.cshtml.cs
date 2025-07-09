using Core.Models;
using Data;
using FoodHunter.Mapper;
using FoodHunter.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;

namespace FoodHunter.Admin.Categories
{
    [BindProperties]
    public class UpdateModel : PageModel
    {
        private readonly ICategoryService _categoryService;
        public CategoryViewModel category { get; set; } = default!;

        public UpdateModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _categoryService.GetCategoryByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            category = product.ToViewModel();
            return RedirectToPage("Index");
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                var entity = category.ToEntity();
                await _categoryService.UpdateCategoryAsync(entity);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            return RedirectToPage("Index");

        }
    }
}
