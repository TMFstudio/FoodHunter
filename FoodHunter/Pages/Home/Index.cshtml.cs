using Core.Models;
using FoodHunter.Mapper;
using FoodHunter.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.Interfaces;
using Service.Services;

namespace FoodHunter.Pages.Home
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IProductTypeService _productTypeService;
        public HomeModel hompageModel { get; set; } = new HomeModel();
        public IndexModel(ICategoryService categoryService, IProductService productService, IProductTypeService productTypeService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _productTypeService = productTypeService;
        }

        protected virtual async Task PrepareHomeModel()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            var products = await _productService.GetAllProductsAsync();
            var productTypes = await _productTypeService.GetAllProductTypesAsync();

            hompageModel.Categories = categories.Select(x=>x.ToModel()).ToList();
            hompageModel.Products = products.Select(x => x.ToModel()).ToList();
            //model.ProductTypes = productTypes;
           
        }
        public async Task<IActionResult> OnGet(int pageindex)
        {
         await   PrepareHomeModel();

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id != 0)
            {

            }
            return RedirectToPage();
        }

    }
}

