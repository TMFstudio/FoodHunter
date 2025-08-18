
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interfaces;
using FoodHunter.Model;
using FoodHunter.Mapper;
using Microsoft.AspNetCore.Authorization;

namespace FoodHunter.Pages.Admin.ProductsType
{
    [BindProperties]
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IProductTypeService  _productTypeService;
        public ProductTypeModel ProductType { get; set; } = default!;

        public CreateModel(IProductTypeService  productTypeService)
        {
            _productTypeService = productTypeService;
        }

        public async Task<IActionResult> OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var entity = ProductType.ToEntity();
                await _productTypeService.InsertProductTypeAsync(entity);
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
