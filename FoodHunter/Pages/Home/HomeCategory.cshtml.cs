using FoodHunter.Mapper;
using FoodHunter.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interfaces;

namespace FoodHunter.Pages.Home
{
    public class HomeCategoryModel : PageModel
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductsCategoriesService _productCategoryService;
        private readonly IProductTypeService _productTypeService;
        public HomePageCategoryModel HompageModel { get; set; } = new HomePageCategoryModel();
        public HomeCategoryModel(ICategoryService categoryService, IProductsCategoriesService productsCategoriesService, IProductTypeService productTypeService)
        {
            _categoryService = categoryService;
            _productCategoryService = productsCategoriesService;
            _productTypeService = productTypeService;
        }

        protected virtual async Task PrepareHomeModel(int categoryId)
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            var products = await _productCategoryService.GetAllProductByCategoryIdAsync(catId:categoryId ,pageSize:24);
            var productTypes = await _productTypeService.GetAllProductTypesAsync();
            if(products!=null)
                HompageModel.Products = products.Select(x => x.ToModel()).ToList();
            if (categories != null)
                HompageModel.Categories = categories.Select(x => x.ToModel()).ToList();

           var cartegory = await _categoryService.GetCategoryByIdAsync(categoryId);

            HompageModel.CategoryName = cartegory.Name;
        }

        public async Task<IActionResult> OnGet(int categoryId)
        {
          await  PrepareHomeModel(categoryId);

            
            return Page();
        }
    }
}
