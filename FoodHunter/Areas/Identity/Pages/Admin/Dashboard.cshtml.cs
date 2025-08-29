using Core.Models;
using FoodHunter.Mapper;
using FoodHunter.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interfaces;
using Service.Services;

namespace FoodHunter.Areas.Identity.Pages.Admin
{
    [Authorize(Roles = "admin,owner")]
    public class IndexModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        public DashboardModel Dashboard { get; set; } = new DashboardModel();
        public IndexModel(IOrderService orderService, IProductService productService, ICustomerService customerService)
        {
            _orderService = orderService;
            _customerService = customerService;
            _productService = productService;
        }
        protected virtual async Task PrepareHomeModel()
        {
            var orders = await _orderService.GetAllOrderAsync();
            var products = await _productService.GetAllProductsAsync();
            var customer = await _customerService.GetUsersAsync();
          
            Dashboard.Orders = orders.Select(x =>
            {
                var m = x.ToModel();
                m.Status = (OrderStatus?)x.StatusId;
                return m;
            }).ToList();
            Dashboard.Products = products.Select(x => x.ToModel()).ToList();
            Dashboard.Customers = customer.Select(x => x.ToModel()).ToList();
            Dashboard.ToDayOrderTotal = 0;
            Dashboard.ToDayOrderCount = 0;
          foreach (var item in  Dashboard.Orders)
            {
                if(item.OrderDate.Day == DateTime.Today.Day)
                {
                    Dashboard.ToDayOrderTotal += item.OrderTotal;
                    Dashboard.ToDayOrderCount += 1;
                }
            }

        }
        public async Task<IActionResult> OnGet(int pageindex)
        {
            await PrepareHomeModel();

            return Page();
        }
    }
}
