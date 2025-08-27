using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FoodHunter.Mapper;
using FoodHunter.Model;
using Microsoft.AspNetCore.Authorization;
using Service.Services;

namespace FoodHunter.Pages.Admin.ProductsCategories
{
    [BindProperties]
    [Authorize(Roles = "admin,owner")]
    public class IndexModel : PageModel
    {
        private readonly IProductsCategoriesService  _productsCategoriesService;
        public ProductCategoryListModel ProductCategory { get; set; } = new ProductCategoryListModel();

        public IndexModel(IProductsCategoriesService  productsCategoriesService)
        {
            _productsCategoriesService = productsCategoriesService;
        }

        public async Task OnGetAsync(int pageindex)
        {
            var products = await _productsCategoriesService.GetAllProductsCategoriesAsync(pageindex: pageindex - 1, pageSize: 6);

            ProductCategory.ProductsCategoriesModels = products.Select(product =>
            {
                var m = product.ToModel();
                return m;
            }).ToList();

            ProductCategory.PageIndex = products.PageIndex;
            ProductCategory.CurrentPage = pageindex;
            ProductCategory.TotalPage = products.TotalPages;

        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id != 0)
            {
                await _productsCategoriesService.DeleteProductCategoryByIdAsync(id);
                return RedirectToPage();
            }
            return RedirectToPage();
        }
    }
}
