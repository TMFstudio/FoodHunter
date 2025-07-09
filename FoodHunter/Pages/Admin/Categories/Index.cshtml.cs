using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FoodHunter.ViewModel;
using FoodHunter.Mapper;
using Service.Repository.Interfaces;

namespace FoodHunter.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryService _categoryService;
        public IEnumerable<CategoryViewModel> categories { get; set; }
        public IndexModel(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }
        public async Task OnGet()
        {
            categories= _categoryService.GetCategories().ToViewModelList();   
        }
        //public async Task<IActionResult> OnPostAsync(int id)
        //{
        //    if (id != 0)
        //    {
        //        var entity = await _categoryService.Categories.FindAsync(id);
        //        _dbContext.Categories.Remove(entity);
        //        await _dbContext.SaveChangesAsync();
        //        return RedirectToPage();
        //    }
        //    return RedirectToPage();
        //}
    }
}
