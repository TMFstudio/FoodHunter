

using Core.Models;
using Core;

namespace Service.Interfaces
{
    public interface IShoppingCartService
    {
        Task IncreamentCountAsync(ShoppingCart shoppingCartitem, int count); 
        Task DecamentCountAsync(ShoppingCart shoppingCartitem, int count);
        Task<IPagedList<ShoppingCart>> GetAllShoppingCartAsync(int pageIndex = 0, int pageSize = int.MaxValue);
        Task<ShoppingCart> GetShoppingCartByIdAsync(int id);
        Task<ShoppingCart> GetShoppingCartByIdAsync(int productId, string customerId);
        Task DeleteShoppingCartByIdAsync(int id);
        Task InsertShoppingCartAsync(ShoppingCart product);   
        
        Task UpdateShoppingCartAsync(ShoppingCart product);
    }
}
