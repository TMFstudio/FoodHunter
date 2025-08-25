using Core.Models;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IOrderService
    {
        Task<IPagedList<Order>> GetAllOrderAsync(int pageIndex = 0, int pageSize = int.MaxValue);
        Task<Order> GetOrderByIdAsync(int id);
        Task DeleteOrderByIdAsync(int id);
        Task InsertOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
    }
}
