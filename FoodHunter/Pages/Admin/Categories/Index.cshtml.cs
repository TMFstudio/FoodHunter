using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FoodHunter.Model;
using FoodHunter.Mapper;
using Service.Interfaces;
using Core;

namespace FoodHunter.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryService _categoryService;
        public CategoryListModel Categories { get; set; }=new CategoryListModel();
        public IndexModel(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }
        public async Task OnGet(int pageindex)
        {
          var categories= await _categoryService.GetAllCategoriesAsync(pageIndex: pageindex -1, pageSize: 5);
           
            var model=   categories.Select(category =>
            {
                var m = category.ToModel();
                return m;
            }).ToList();
           
            Categories.categoryModels = model;
           Categories.PageIndex= categories.PageIndex;
           Categories.CurrentPage = pageindex;
            Categories.TotalPage= categories.TotalPages;
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
