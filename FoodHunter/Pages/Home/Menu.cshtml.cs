using FoodHunter.Mapper;
using FoodHunter.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interfaces;

namespace FoodHunter.Pages.Home
{
    public class MenuModel : PageModel
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IProductTypeService _productTypeService;
        public MenuItemsModel MenuItemsModel { get; set; } = new MenuItemsModel();
        public MenuModel(ICategoryService categoryService, IProductService productService, IProductTypeService productTypeService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _productTypeService = productTypeService;
        }

        protected virtual async Task PrepareHomeModel()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            var products = await _productService.GetAllProductsAsync(pageSize:8);
            var productTypes = await _productTypeService.GetAllProductTypesAsync();
            if (products != null)
                MenuItemsModel.Products = products.Select(x => x.ToModel()).ToList();
            if (categories != null)
                MenuItemsModel.Categories = categories.Select(x => x.ToModel()).ToList();
            if (productTypes != null)
                MenuItemsModel.ProductTypes = productTypes.Select(x => x.ToModel()).ToList();


        }

        public async Task<IActionResult> OnGet()
        {
            await PrepareHomeModel();


            return Page();
        }
    }
}
