using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Core.Models;
using Data;
using FoodHunter.ViewModel;
using FoodHunter.Mapper;
using Service.Repository.Interfaces;
using Service.Repository.Services;

namespace FoodHunter.Pages.Admin.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        public IEnumerable<ProductViewModel> Products { get; set; }

        public IndexModel(IProductService productService)
        {
            _productService = _productService;
        }

        public async Task OnGetAsync()
        {
            //prepare
            var entity = await _productService.GetAllProductsAsync();
            Products = entity.ToViewModelList();

        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id != 0)
            {
                await _productService.DeleteProductByIdAsync(id);
                return RedirectToPage();
            }
            return RedirectToPage();
        }
    }
}
