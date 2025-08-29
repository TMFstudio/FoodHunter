using Core.Models;
using FoodHunter.Mapper;
using FoodHunter.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interfaces;
using System.Security.Claims;

namespace FoodHunter.Pages.Admin.Orders
{
    [Authorize(Roles = "admin,owner")]
    public class Index1Model : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        public OrderListModel  OrdersModel { get; set; } = new OrderListModel();
        public Index1Model(IOrderService orderService, ICustomerService customerService)
        {
            _orderService= orderService;
            _customerService= customerService;
        }
        public async Task<IActionResult> OnGetAsync(int pageindex)
        {
            var order = await _orderService.GetAllOrderAsync(pageIndex: pageindex - 1, pageSize: 10);
            OrdersModel.Orders = order.Select( order =>
            {
                var m = order.ToModel();
                m.Status =(OrderStatus?)order.StatusId;
                var customer = _customerService.GetCustomerById(order.CustomerId).Result;
                m.CustomerName = customer.FirstName +" "+customer.LastName;
                m.PhoneNumber= customer.PhoneNumber;

                return m;
            }).ToList();
            OrdersModel.PageIndex = order.PageIndex;
            OrdersModel.CurrentPage = pageindex;
            OrdersModel.TotalPage = order.TotalPages;
            return Page();
        }
    }
}
