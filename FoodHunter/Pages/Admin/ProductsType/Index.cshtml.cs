using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interfaces;
using FoodHunter.Model;
using FoodHunter.Mapper;

namespace FoodHunter.Pages.Admin.ProductsType
{
    public class IndexModel : PageModel
    {
        private readonly IProductTypeService _productTypeService;
        public IEnumerable<ProductTypeModel> ProductTypes { get; set; } = default!;

        public IndexModel(IProductTypeService  productTypeService)
        {
            _productTypeService = productTypeService;
        }
        public async Task OnGetAsync()
        {
            //prepare
            var entity = await _productTypeService.GetAllProductTypesAsync();
            ProductTypes = entity.ToModelList();

        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id != 0)
            {
                await _productTypeService.DeleteProductTypeByIdAsync(id);
                return RedirectToPage();
            }
            return RedirectToPage();
        }

        }
    }
