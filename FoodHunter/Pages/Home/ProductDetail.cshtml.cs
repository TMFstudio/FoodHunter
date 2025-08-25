using FoodHunter.Mapper;
using FoodHunter.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interfaces;
using System.Security.Claims;

namespace FoodHunter.Pages.Home
{
    [Authorize]
    [BindProperties]
    public class ProductDetail : PageModel
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IProductService _productService;
        private readonly IProductsCategoriesService _productCategoryService;
        public ProductDetail(IProductService productService, IProductsCategoriesService productCategoryService, IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
            _productService = productService;
            _productCategoryService = productCategoryService;

        }
        public ShoppingCartItemModel ShoppingCartModel { get; set; } = new ShoppingCartItemModel();

        private async Task PrepareProductDetailViewModel(int productId)
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var product = await _productService.GetProductByIdAsync(productId);
            var cartItem = await _shoppingCartService.GetShoppingCartByIdAsync(product.Id, claim.Value);
       
            if(cartItem !=null)
                ShoppingCartModel.ItemsCount = cartItem.Count;
            else
            ShoppingCartModel.ItemsCount = 0;

            ShoppingCartModel.Product.Price = product.Price;
            ShoppingCartModel.Product.Name = product.Name;
            ShoppingCartModel.Product.Description = product.Description;
            ShoppingCartModel.Product.CreateDate = product.CreateDate;
            ShoppingCartModel.Product.Image = product.Image;
            ShoppingCartModel.Product.ProductTypeName = product.ProductType.Name;
            var productCategory = await _productCategoryService.GetAllProductsCategoriesAsync(productId: productId);
            ShoppingCartModel.Product.Categories = productCategory.Select(pc => pc.Category.ToModel()).Distinct().ToList();
        }
        private void PrepareShoppingCartItemViewModel(int id)
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ShoppingCartModel.CustomerId = claim.Value;
            ShoppingCartModel.ProductId = id;
            ShoppingCartModel.CreateOn = DateTime.Now;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if(id!=0)
            await PrepareProductDetailViewModel(id);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (ModelState.IsValid)
            {
                PrepareShoppingCartItemViewModel(id);
                var entity = ShoppingCartModel.ToEntity();
                var shoppingCartItem = await _shoppingCartService.GetShoppingCartByIdAsync(entity.ProductId,entity.ApplicationUserId);
                if (shoppingCartItem == null)
                {
                    await _shoppingCartService.InsertShoppingCartAsync(entity);
                }
                else
                {
                    await _shoppingCartService.IncreamentCountAsync(shoppingCartItem);
                }
                return RedirectToAction("Index", new { id = id } );
            }

            return Page();
        }
    }
}

