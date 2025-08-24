using FoodHunter.Mapper;
using FoodHunter.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interfaces;
using System.Security.Claims;

namespace FoodHunter.Pages.Customer.Cart
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly ICategoryService _categoryService;
        public ShoppingCartModel ShoppingCartModel { get; set; } = new ShoppingCartModel();

        public IndexModel(IShoppingCartService shoppingCartService, ICategoryService categoryService)
        {
            _shoppingCartService = shoppingCartService;
            _categoryService=categoryService;

        }
        private async Task PrepareShoppingCart()
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var cartItem = await _shoppingCartService.GetAllShoppingCartsProductAsync(claim.Value);

            if (cartItem != null)
            {
                ShoppingCartModel.CartItems = cartItem.Select(x => x.ToModel()).ToList();
                var category =await _categoryService.GetAllCategoriesAsync();

                foreach (var item in cartItem)
                {
                    ShoppingCartModel.OrderTotal = 0;
                    ShoppingCartModel.Products.Add( new ProductDetailModel
                    {
                        Name = item.Product.Name,
                        Description = item.Product.Description,
                        CreateDate = item.Product.CreateDate,
                        Image = item.Product.Image,
                        Price = item.Product.Price,
                        ProductTypeId = item.Product.ProductTypeId,
                        Categories = category.Select(x => x.ToModel()).ToList(),
                        CartItemCount=item.Count
                    });
                   
                       ShoppingCartModel.OrderTotal += item.Product.Price * item.Count;
                       ShoppingCartModel.ItemCount +=  item.Count;
           
                }
            }
        }
        public async Task<IActionResult> OnGet()
        {
            await PrepareShoppingCart();

            return Page();
        }
    }
}
