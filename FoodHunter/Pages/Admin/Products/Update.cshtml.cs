
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FoodHunter.Mapper;
using Service.Interfaces;
using FoodHunter.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodHunter.Pages.Admin.Products
{
    [BindProperties]
    public class UpdateModel : PageModel
    {
        private readonly IProductTypeService _productTypeService;
        private readonly IProductService _productService;
        public UpdateModel(IProductService productService, IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
            _productService = productService;
        }
        public ProductModel Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _productService.GetProductByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            //prepare product type
            var productsType = await _productTypeService.GetAllProductTypesAsync();
            Product = product.ToModel();

            Product.ProductType= productsType.Select(item => new SelectListItem
                  {
                      Text = item.Name,
                      Value = item.Id.ToString()
                  }).ToList();
          

          
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
                var entity = Product.ToEntity();

                await _productService.UpdateProductAsync(entity);
            }
            catch (DbUpdateConcurrencyException)
            {
                    return NotFound();
            }

            return RedirectToPage("./Index");
        }
    }
}
