
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interfaces;
using FoodHunter.ViewModel;
using FoodHunter.Mapper;


namespace FoodHunter.Pages.Admin.Products
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IProductService _productService;
        public ProductViewModel Product { get; set; } = default!;

        public CreateModel(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> OnGet()
        {
            //ViewData["ProductTypeId"] = new SelectList(_productService.ProductTypes, "Id", "Name");
            return Page();
        }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
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
