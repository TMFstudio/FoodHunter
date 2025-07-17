
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interfaces;
using FoodHunter.Mapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using FoodHunter.Model;
using Core.Models;


namespace FoodHunter.Pages.Admin.Products
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IProductTypeService _productTypeService;
        public ProductModel Product { get; set; } = default!;



        public CreateModel(IProductService productService, IProductTypeService productTypeService)
        {
            _productService = productService;
            _productTypeService = productTypeService;
        }

        public async Task<IActionResult> OnGet()
        {                                     
            var products=await _productTypeService.GetAllProductTypesAsync();
            Product = new ProductModel
            {
                ProductType = products.Select(item => new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                }).ToList()
            };
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var entity = Product.ToEntity();
                await _productService.InsertProductAsync(entity);
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
