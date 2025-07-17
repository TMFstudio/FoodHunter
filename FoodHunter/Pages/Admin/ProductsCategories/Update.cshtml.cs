
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Models;
using Service.Interfaces;
using FoodHunter.Mapper;
using FoodHunter.Model;
using Service.Services;

namespace FoodHunter.Pages.Admin.ProductsCategories
{
    [BindProperties]
    public class UpdateModel : PageModel
    {
        private readonly IProductsCategoriesService _productsCategoriesService;
        public ProductCategoryModel ProductCategory { get; set; } = default!;

        public UpdateModel(IProductsCategoriesService  productsCategoriesService)
        {
            _productsCategoriesService = productsCategoriesService;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = await _productsCategoriesService.GetProductCategoryByIdAsync(id.Value);
            if (productCategory == null)
            {
                return NotFound();
            }
            ProductCategory = productCategory.ToModel();
           // ViewData["CategoryId"] = new SelectList(productCategory.Categories, "Id", "Description");
           //ViewData["ProductId"] = new SelectList(productCategory.Products, "Id", "CreateDate");
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                var entity = ProductCategory.ToEntity();

                await _productsCategoriesService.UpdateProductCategoryAsync(entity);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return RedirectToPage("./Index");
        }
    }
}
