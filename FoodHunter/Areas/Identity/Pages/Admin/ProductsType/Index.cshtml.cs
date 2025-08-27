using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interfaces;
using FoodHunter.Model;
using FoodHunter.Mapper;
using Microsoft.AspNetCore.Authorization;
using Core.Models;

namespace FoodHunter.Pages.Admin.ProductsType
{
    [Authorize(Roles = "admin,owner")]
    public class IndexModel : PageModel
    {
        private readonly IProductTypeService _productTypeService;
        public ProductTypeListModel ProductTypes { get; set; } = new ProductTypeListModel();

        public IndexModel(IProductTypeService  productTypeService)
        {
            _productTypeService = productTypeService;
        }
        public async Task OnGetAsync(int pageindex)
        {
            //prepare
            var entity = await _productTypeService.GetAllProductTypesAsync(pageIndex: pageindex - 1, pageSize: 6);
            ProductTypes.ProductTypeModels = entity.Select(productType =>
            {
                var m = productType.ToModel();
                return m;
            }).ToList();
            ProductTypes.PageIndex = entity.PageIndex;
            ProductTypes.CurrentPage = pageindex;
            ProductTypes.TotalPage = entity.TotalPages;
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
