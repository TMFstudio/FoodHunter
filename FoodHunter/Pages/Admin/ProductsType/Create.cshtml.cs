using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Core.Models;
using Data;
using Service.Interfaces;
using Service.Services;
using FoodHunter.ViewModel;
using FoodHunter.Mapper;

namespace FoodHunter.Pages.Admin.ProductsType
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IProductTypeService  _productTypeService;
        public ProductTypeViewModel ProductType { get; set; } = default!;

        public CreateModel(IProductTypeService  productTypeService)
        {
            _productTypeService = productTypeService;
        }

        public async Task<IActionResult> OnGet()
        {
            //ViewData["ProductTypeId"] = new SelectList(_productService.ProductTypes, "Id", "Name");
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
