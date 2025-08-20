using FoodHunter.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;

namespace FoodHunter.Pages.Home
{
    public class ProductDetailModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IProductsCategoriesService _productCategoryService;
        public ProductDetailModel(IProductService productService, IProductsCategoriesService productCategoryService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
        }
        public ProductsDetailModel ProductsDetailModel { get; set; } = new ProductsDetailModel();

        private async Task PrepareProductDetailViewModel(int productId)
        {
            var product = await _productService.GetProductByIdAsync(productId);
            ProductsDetailModel.Price = product.Price;
            ProductsDetailModel.Name = product.Name;
            ProductsDetailModel.Description = product.Description;
            ProductsDetailModel.CreateDate = product.CreateDate;
            ProductsDetailModel.Image = product.Image;
            ProductsDetailModel.ProductTypeName = product.ProductType.Name;
            var productCategory = await _productCategoryService.GetAllProductsCategoriesAsync(productId: productId);
            ProductsDetailModel.categories = productCategory.Select(pc => pc.Category).Distinct().ToList();


        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
        await    PrepareProductDetailViewModel(id);
            return Page();
        }
    }
}

