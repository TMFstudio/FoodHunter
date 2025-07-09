using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Core.Models;
using Service.Interfaces;

namespace FoodHunter.Pages.Admin.Products
{
    public class DetailsModel : PageModel
    {
        private readonly IProductService _productService;

        public Product Product { get; set; } = default!;
        public DetailsModel(IProductService  productService)
        {
            _productService = productService;
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
            else
            {
                Product = product;
            }
            return Page();
        }
    }
}
