

using Core.Models;
using Core;
using System.Linq.Expressions;

namespace Service.Interfaces
{
    public interface IShoppingCartService
    {
        Task IncreamentCountAsync(ShoppingCart shoppingCartitem); 
        Task DecrementCountAsync(ShoppingCart shoppingCartitem);
        Task<IPagedList<ShoppingCart>> GetAllShoppingCartAsync(int pageIndex = 0, int pageSize = int.MaxValue);
        Task<IEnumerable<ShoppingCart>> GetAllShoppingCartAsync(Expression<Func<ShoppingCart, bool>>? filter = null);
        Task<IEnumerable<ShoppingCart>> GetAllShoppingCartsProductAsync(string? CustomerId = null);
        Task<ShoppingCart> GetShoppingCartByIdAsync(int id);
        Task<ShoppingCart> GetShoppingCartByIdAsync(int productId, string customerId);
        Task DeleteShoppingCartByIdAsync(int id);
        Task InsertShoppingCartAsync(ShoppingCart product);   
        
        Task UpdateShoppingCartAsync(ShoppingCart product);
    }
}
