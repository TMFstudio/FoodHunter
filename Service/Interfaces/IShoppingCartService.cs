

using Core.Models;
using Core;

namespace Service.Interfaces
{
    public interface IShoppingCartService
    {
        Task<IPagedList<ShoppingCart>> GetAllShoppingCartAsync(int pageIndex = 0, int pageSize = int.MaxValue);
        Task<ShoppingCart> GetShoppingCartByIdAsync(int id);
        Task DeleteShoppingCartByIdAsync(int id);
        Task InsertShoppingCartAsync(ShoppingCart product);
        Task UpdateShoppingCartAsync(ShoppingCart product);
    }
}
