using Core;
using Core.Models;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;
using System.Linq.Expressions;


namespace Service.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<ShoppingCart> _ShoppingCartRepository;

        public ShoppingCartService(IRepository<ShoppingCart> shoppingCartrepository)
        {
            _ShoppingCartRepository = shoppingCartrepository;
        }

        #region CartItem
        public async Task DeleteShoppingCartByIdAsync(int id)
        {
            var entity = await _ShoppingCartRepository.GetByIdAsync(id: id);

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
                query = query.OrderByDescending(x => x.Id);
                return query;
            }, pageIndex, pageSize);
        }
        public async Task<ShoppingCart> GetShoppingCartByIdAsync(string customerId,int? productId=0, int? id=0)
        {
            var query = _ShoppingCartRepository.Table.AsQueryable();

                query = query.Where(q => q.ApplicationUserId == customerId);

            if (productId.HasValue && productId.Value > 0)
                query = query.Where(q => q.ProductId == productId.Value);

            if (id.HasValue && id.Value > 0)
                query = query.Where(q => q.Id == id.Value);

            return await query.FirstOrDefaultAsync();
 
        }
        public async Task IncreamentCountAsync(ShoppingCart shoppingCartitem)
        {
            shoppingCartitem.Count += 1;
            await _ShoppingCartRepository.UpdateAsync(shoppingCartitem);
        }
        public async Task DecrementCountAsync(ShoppingCart shoppingCartitem)
        {
            shoppingCartitem.Count -= 1;
            await _ShoppingCartRepository.UpdateAsync(shoppingCartitem);
        }
        public async Task InsertShoppingCartAsync(ShoppingCart product)
        {
            await _ShoppingCartRepository.InsertAsync(product);
        }
        public async Task UpdateShoppingCartAsync(ShoppingCart product)
        {
            await _ShoppingCartRepository.UpdateAsync(product);
        }
        public async Task<IEnumerable<ShoppingCart>> GetAllShoppingCartAsync(Expression<Func<ShoppingCart, bool>>? filter = null)
        {
            return await _ShoppingCartRepository.GetAllsAsync(filter,func: async query =>
            {

                query=query.Include(x=>x.Product);
                query = query.OrderByDescending(x => x.Id);

                return query;
            });
        }
        public async Task<IEnumerable<ShoppingCart>> GetAllShoppingCartsProductAsync(string? CustomerId=null)
        {
            return await _ShoppingCartRepository.GetAllsAsync(func:async query =>
            {
                //bring Customer with productids
                if (CustomerId != null)
                    query = query.Where(x => x.ApplicationUserId == CustomerId).Include(x => x.Product);

                query = query.OrderByDescending(x => x.Id);

                return query;
            });
        }
        public async Task DeleteShoppingCartRangeAsync(IEnumerable<ShoppingCart> shoppingCarts)
        {
         await   _ShoppingCartRepository.RemoveRangeAsync(shoppingCarts);
        }

        #endregion


    }
}
