using FoodHunter.Mapper;
using FoodHunter.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interfaces;
using Service.Services;
using System.Security.Claims;

namespace FoodHunter.Pages.Customer.Cart
{
    [Authorize]
    [BindProperties]
    public class SummaryModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly ICustomerService _customerService;
        private readonly ICategoryService _categoryService;

        public SummaryModel(IOrderService orderService, IShoppingCartService shoppingCartService, ICategoryService categoryService, ICustomerService customerService)
        {
            _orderService = orderService;
            _shoppingCartService = shoppingCartService;
            _categoryService = categoryService;
            _customerService = customerService;
        }
        public OrderModel OrderModel { get; set; } = new OrderModel();
        public ShoppingCartModel ShoppingCartModel { get; set; } = new ShoppingCartModel();

        private async Task PrepareShoppingCart()
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var cartItem = await _shoppingCartService.GetAllShoppingCartsProductAsync(claim.Value);
            var customer =await _customerService.GetCustomerById(claim.Value);
            OrderModel.PickUpName = customer.FirstName + "" + customer.LastName;
            OrderModel.PhoneNumber = customer.PhoneNumber ;
            if (cartItem != null)
            {
                ShoppingCartModel.CartItems = cartItem.Select(x => x.ToModel()).ToList();
                var category = await _categoryService.GetAllCategoriesAsync();

                foreach (var item in cartItem)
                {
                    ShoppingCartModel.OrderTotal = 0;
                    ShoppingCartModel.Products.Add(new ProductDetailModel
                    {
                        Id = item.ProductId,
                        Name = item.Product.Name,
                        Description = item.Product.Description,
                        CreateDate = item.Product.CreateDate,
                        Image = item.Product.Image,
                        Price = item.Product.Price,
                        ProductTypeId = item.Product.ProductTypeId,
                        Categories = category.Select(x => x.ToModel()).ToList(),
                        CartItemCount = item.Count
                    });

                    ShoppingCartModel.OrderTotal += item.Product.Price * item.Count;
                    ShoppingCartModel.ItemCount += item.Count;

                }
            }
        }
        public async Task<IActionResult> OnGet()
        {
          await  PrepareShoppingCart();
            return Page();
  
        }
        public void OnPost()
        {
        }
    }
}
