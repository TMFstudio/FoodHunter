using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interfaces;
using FoodHunter.ViewModel;
using FoodHunter.Mapper;

namespace FoodHunter.Pages.Admin.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IProductTypeService _productTypeService;
        public IEnumerable<ProductViewModel> Products { get; set; } = default!;

        public IndexModel(IProductService productService, IProductTypeService productTypeService)
        {
            _productService = productService;
            _productTypeService  = productTypeService;
        }

        public async Task OnGetAsync()
        {
            var entity = await _productService.GetAllProductsAsync();
               if(entity != null) 
                Products= entity.ToViewModelList();
    ;
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
