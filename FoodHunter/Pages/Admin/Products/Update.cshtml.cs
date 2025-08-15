
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
        public ProductModel Product { get; set; } = new ProductModel();
        protected virtual async Task PrepareProductCategory()
        {
            var products = await _productTypeService.GetAllProductTypesAsync();
            Product = new ProductModel
            {
                ProductType = products.Select(item => new SelectListItem
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
           var product = await _productService.GetProductByIdAsync(id.Value);

            if (product == null)
            {
                return NotFound();
            }
            await PrepareProductCategory();
            Product = product.ToModel();



            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await PrepareProductCategory();
                var entity = Product.ToEntity();
                if (entity == null)
                {
                    return NotFound();
                }
                await _productService.UpdateProductAsync(entity);
                return RedirectToPage("./Index");
            }
            await PrepareProductCategory();

            return Page();
        }
    }
}
