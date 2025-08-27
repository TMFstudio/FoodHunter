using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;
using FoodHunter.Mapper;
using FoodHunter.Model;
using Microsoft.AspNetCore.Authorization;

namespace FoodHunter.Pages.Admin.ProductsCategories
{
    [BindProperties]
    [Authorize(Roles = "admin,owner")]
    public class UpdateModel : PageModel
    {
        private readonly IProductsCategoriesService _productsCategoriesService;
        public ProductCategoryModel ProductCategory { get; set; } = default!;

        public UpdateModel(IProductsCategoriesService  productsCategoriesService)
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

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _productsCategoriesService.GetProductCategoryAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }
          await  PrepareProductCategory();


            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            var isProductCategoryExist = await _productsCategoriesService.CheckProductCategoryExistenceAsync(ProductCategory.CategoryId, ProductCategory.ProductId);
            if (isProductCategoryExist)
            {
                ModelState.AddModelError(string.Empty, "This Relation Exist");
            }
            if (!ModelState.IsValid)
            {
                var entity = await _productsCategoriesService.GetProductCategoryAsync(ProductCategory.Id);
                if (entity == null)
                {
                    return NotFound();
                }
                entity = ProductCategory.ToEntity();
                return RedirectToPage("./Index");

            }

            await PrepareProductCategory();
            return Page();
        }

    
    }
}
