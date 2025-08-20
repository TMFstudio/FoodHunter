using Core;
using Core.Models;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;


namespace Service.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<ShoppingCart> _ShoppingCartRepository;

        public ShoppingCartService(IRepository<ShoppingCart> shoppingCartrepository)
        {
            _ShoppingCartRepository = shoppingCartrepository;
        }
        public async Task DeleteShoppingCartByIdAsync(int id)
        {
            var entity = await _ShoppingCartRepository.GetByIdAsync(id);

            if (entity != null)
            {
                await _ShoppingCartRepository.RemoveAsync(entity);
            }
        }

        public async Task<IPagedList<ShoppingCart>> GetAllShoppingCartAsync(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return await _ShoppingCartRepository.GetAllPagedAsync(async query =>
            {
                query = query.Include(x => x.Product).Include(x => x.ApplicationUser);
                query.OrderByDescending(x => x.CreateOn);
                return query;

            }, pageIndex, pageSize);
        }

        public async Task<ShoppingCart> GetShoppingCartByIdAsync(int id)
        {
            return await _ShoppingCartRepository.GetByIdAsync(id);
        }

        public async Task InsertShoppingCartAsync(ShoppingCart product)
        {
            await _ShoppingCartRepository.InsertAsync(product);
        }

        public async Task UpdateShoppingCartAsync(ShoppingCart product)
        {
            await _ShoppingCartRepository.UpdateAsync(product);
        }
    }
}
