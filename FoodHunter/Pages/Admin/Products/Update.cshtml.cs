
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Models;
using Data;
using Service.Repository.Interfaces;
using FoodHunter.Mapper;
using FoodHunter.ViewModel;

namespace FoodHunter.Pages.Admin.Products
{
    public class UpdateModel : PageModel
    {
        private readonly IProductService _productService;
        public UpdateModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public ProductViewModel Product { get; set; } = default!;

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
            Product = product.ToViewModel();
            //ViewData["ProductTypeId"] = new SelectList(_productService.ProductTypes, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
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
