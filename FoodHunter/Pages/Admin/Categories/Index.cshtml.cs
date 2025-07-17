using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FoodHunter.Model;
using FoodHunter.Mapper;
using Service.Interfaces;

namespace FoodHunter.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryService _categoryService;
        public IEnumerable<CategoryModel> categories { get; set; } = default!;
        public IndexModel(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }
        public async Task OnGet()
        {
          var entity= await _categoryService.GetCategoriesAsync();  
            categories=entity.ToModelList();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id != 0)
            {
               await _categoryService.DeleteCategoryByIdAsync(id);
                return RedirectToPage();
            }
            return RedirectToPage();
        }
    }
}
