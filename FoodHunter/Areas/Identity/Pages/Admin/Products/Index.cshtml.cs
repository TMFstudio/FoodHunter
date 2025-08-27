using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interfaces;
using FoodHunter.Model;
using FoodHunter.Mapper;
using Microsoft.AspNetCore.Authorization;

namespace FoodHunter.Pages.Admin.Products
{
    [Authorize(Roles = "admin,owner")]
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IProductTypeService _productTypeService;
        public ProductListModel Products { get; set; } = new ProductListModel();

        public IndexModel(IProductService productService, IProductTypeService productTypeService)
        {
            _productService = productService;
            _productTypeService  = productTypeService;
        }
        public async Task OnGet(int pageindex)
        {
            var products = await _productService.GetAllProductsAsync(pageIndex: pageindex - 1, pageSize: 6);

            Products.ProductModels = products.Select(product =>
            {
                var m = product.ToModel();
                return m;
            }).ToList();

            Products.PageIndex = products.PageIndex;
            Products.CurrentPage = pageindex;
            Products.TotalPage = products.TotalPages;
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
