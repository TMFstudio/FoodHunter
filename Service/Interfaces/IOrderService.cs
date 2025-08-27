using Core.Models;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Service.Interfaces
{
    public interface IOrderService
    {
        Task<IPagedList<Order>> GetAllOrderAsync(int pageIndex = 0, int pageSize = int.MaxValue);
        Task<IPagedList<OrderItem>> GetAllOrderItemsAsync(int pageIndex = 0, int pageSize = int.MaxValue);
        Task<Order> GetOrderByIdAsync(int id);
        Task<Order> AddOrderAsync(Order order);
        Task<Order> GetOrderByIdAsync(Expression<Func<Order, bool>> filter);
        Task DeleteOrderByIdAsync(int id);
        Task InsertOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task InsertOrderItemAsync(OrderItem orderItem);

    }
}
