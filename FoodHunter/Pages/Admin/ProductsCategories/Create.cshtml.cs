
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FoodHunter.Mapper;
using FoodHunter.Model;
using Service.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.Services;
using Core.Models;
using Microsoft.Extensions.Hosting;

namespace FoodHunter.Pages.Admin.ProductsCategories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IProductsCategoriesService _productsCategoriesService;
        public ProductCategoryModel ProductCategory { get; set; } = default!;
        public CreateModel(IProductsCategoriesService productsCategoriesService)
        {
            _productsCategoriesService = productsCategoriesService;
        }
        protected virtual async Task PrepareProductCategory()
        {
            var product = await _productsCategoriesService.GetAllProductAsync();
            var Categories = await _productsCategoriesService.GetAllCategoriesAsync();
            ProductCategory = new ProductCategoryModel
            {
                Product = product.Select(item => new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                }).ToList(),
                Category = Categories.Select(item => new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                }).ToList()
            };
        }

        public async Task<IActionResult> OnGet()
        {
            await PrepareProductCategory();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var isProductCategoryExist = await _productsCategoriesService.CheckProductCategoryExistenceAsync(ProductCategory.CategoryId, ProductCategory.ProductId);
            if (isProductCategoryExist)
            {
                ModelState.AddModelError(string.Empty, "This Relation Exist");
            }
            if (ModelState.IsValid )
            {
       
                var entity = ProductCategory.ToEntity();
                await _productsCategoriesService.InsertProductCategoryAsync(entity);
                return RedirectToPage("Index");
            }

            await PrepareProductCategory();
            return Page();
        }
    }
}
