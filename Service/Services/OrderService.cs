using Core;
using Core.Models;
using Data.Repository;
using Service.Interfaces;
using System.Linq.Expressions;

namespace Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<OrderItem> _orderItemRepository;
        public OrderService(IRepository<Order> orderRepository, IRepository<OrderItem> orderItemRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
        }
        public async Task DeleteOrderByIdAsync(int id)
        {
            var entity = await _orderRepository.GetByIdAsync(id: id);
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
            return await _orderRepository.GetByIdAsync(id: id);
        }

        public async Task InsertOrderAsync(Order order)
        {
            await _orderRepository.InsertAsync(order);
        }
        public async Task<Order> AddOrderAsync(Order order)
        {
            return await _orderRepository.AddAsync(order);
        }

        public async Task UpdateOrderAsync(Order order)
        {
            await _orderRepository.UpdateAsync(order);
        }

        public async Task<Order> GetOrderByIdAsync(Expression<Func<Order, bool>> filter)
        {
            return await _orderRepository.GetByIdAsync(filter: filter);
        }
        public async Task InsertOrderItemAsync(OrderItem orderItem)
        {
            await _orderItemRepository.InsertAsync(orderItem);
        }
        public async Task<IPagedList<OrderItem>> GetAllOrderItemsAsync(int pageIndex = 0, int pageSize = int.MaxValue, int? orderId = 0, int? productId = 0)
        {
            return await _orderItemRepository.GetAllPagedAsync(async query =>
            {
                if (orderId != 0)
                    query = query.Where(q => q.OrderId == orderId);

                if (productId != 0)
                    query = query.Where(q => q.ProductId == productId.Value);
                query = query.OrderByDescending(x => x.OrderId);
                return query;
            }, pageIndex, pageSize: pageSize);
        }

        public async Task ChangeOrderStatusIdAsync(int orderId,int orderStatusId)
        {
            var query = await _orderRepository.GetByIdAsync(id: orderId);
            query.StatusId = orderStatusId;
          await  _orderRepository.UpdateAsync(query);
        }
    }
}
