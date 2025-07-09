using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FoodHunter.ViewModel;
using FoodHunter.Mapper;
using Service.Interfaces;

namespace FoodHunter.Pages.Admin.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        public IEnumerable<ProductViewModel> Products { get; set; } = default!;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
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
