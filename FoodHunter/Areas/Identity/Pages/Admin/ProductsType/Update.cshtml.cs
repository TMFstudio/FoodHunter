using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Models;
using Service.Interfaces;
using FoodHunter.Mapper;
using FoodHunter.Model;
using Microsoft.AspNetCore.Authorization;

namespace FoodHunter.Pages.Admin.ProductsType
{
    [BindProperties]
    [Authorize]
    public class UpdateModel : PageModel
    {
        private readonly IProductTypeService  _productTypeService;
        public ProductTypeModel ProductType { get; set; } = default!;


        public UpdateModel(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productTypeService.GetProductTypeByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            ProductType = product.ToModel();
            //ViewData["ProductTypeId"] = new SelectList(_productService.ProductTypes, "Id", "Name");
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                var entity = ProductType.ToEntity();

                await _productTypeService.UpdateProductTypeAsync(entity);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return RedirectToPage("./Index");
        }
    }
}
