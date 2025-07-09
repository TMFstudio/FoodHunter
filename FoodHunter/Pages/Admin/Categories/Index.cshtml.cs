using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FoodHunter.ViewModel;
using FoodHunter.Mapper;
using Service.Interfaces;

namespace FoodHunter.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryService _categoryService;
        public IEnumerable<CategoryViewModel> categories { get; set; } = default!;
        public IndexModel(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }
        public async Task OnGet()
        {
          var entity= await _categoryService.GetCategoriesAsync();  
            categories=entity.ToViewModelList();
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
