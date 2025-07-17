using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FoodHunter.Mapper;
using FoodHunter.Model;

namespace FoodHunter.Pages.Admin.ProductsCategories
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly IProductsCategoriesService  _productsCategoriesService;
        public IEnumerable<ProductCategoryModel> ProductCategory { get; set; } = default!;

        public IndexModel(IProductsCategoriesService  productsCategoriesService)
        {
            _productsCategoriesService = productsCategoriesService;
        }

        public async Task OnGetAsync()
        {
            var entity = await _productsCategoriesService.GetAllProductsCategoriesAsync();
            ProductCategory = entity.ToModelList();

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
