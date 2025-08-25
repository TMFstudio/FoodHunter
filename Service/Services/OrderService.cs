using Core;
using Core.Models;
using Data.Repository;
using Service.Interfaces;

namespace Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task DeleteOrderByIdAsync(int id)
        {
            var entity = await _orderRepository.GetByIdAsync(id);
            if (entity != null)
            {
                await _orderRepository.RemoveAsync(entity);
            }
        }

        public async Task<IPagedList<Order>> GetAllOrderAsync(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return await _orderRepository.GetAllPagedAsync(async query =>
            {
                query = query.OrderByDescending(x => x.OrderDate);
                return query;
            }, pageIndex, pageSize: pageSize);
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task InsertOrderAsync(Order order)
        {
          await _orderRepository.InsertAsync(order);
        }

        public async Task UpdateOrderAsync(Order order)
        {
            await _orderRepository.UpdateAsync(order);
        }
    }
}
