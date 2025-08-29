using FoodHunter.Mapper;
using FoodHunter.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interfaces;

namespace FoodHunter.Areas.Admin.Orders
{
    [Authorize(Roles = "admin,owner")]
    [BindProperties]
    public class DetailModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        public OrderDetailModel OrderDetail { get; set; } = new OrderDetailModel();

        public DetailModel(IOrderService orderService, ICustomerService customerService)
        {
            _orderService = orderService;
            _customerService = customerService;
        }
        public async Task<IActionResult> OnGetAsync(int orderId)
        {
            var order = await _orderService.GetOrderByIdAsync(orderId);
            if (order != null)
            {
                var customer = await _customerService.GetCustomerById(order.CustomerId);
                var orderItem = await _orderService.GetAllOrderItemsAsync(orderId: orderId);
                OrderDetail.Order = order.ToModel();
                OrderDetail.OrderItems = orderItem.ToModelList();
                OrderDetail.CustomerName = customer.FirstName + " " + customer.LastName;
                OrderDetail.Email = customer.Email;
                OrderDetail.PhoneNumber = customer.PhoneNumber;
            }

            return Page(); 
        }
        public async Task<IActionResult> OnPostAsync(int orderId,int? orderStatusId=0)
        {
          await  _orderService.ChangeOrderStatusIdAsync(orderId, orderStatusId.Value);
            return RedirectToPage(routeValues: new {orderId});
        }
    }
}
