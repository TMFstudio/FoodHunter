
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FoodHunter.Mapper;
using FoodHunter.ViewModel;
using Service.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.Services;

namespace FoodHunter.Pages.Admin.ProductsCategories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IProductsCategoriesService _productsCategoriesService;
        public ProductCategoryViewModel ProductCategory { get; set; } = default!;
        public CreateModel(IProductsCategoriesService  productsCategoriesService)
        {
            _productsCategoriesService = productsCategoriesService;
        }

        public async Task<IActionResult> OnGet()
        {
            var productsCategories = await _productsCategoriesService.GetAllProductAsync();
            ViewData["ProductId"] = new SelectList(productsCategories, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(productsCategories, "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var entity = ProductCategory.ToEntity();
                await _productsCategoriesService.InsertProductCategoryAsync(entity);
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
