using Core.Models;
using System.ComponentModel.DataAnnotations;

namespace FoodHunter.Model
{
    public record ShoppingCartModel : BaseModel
    {
        public ShoppingCartModel() { }

        public int ItemCount { get; set; }
        public double? OrderTotal { get; set; }
        public ApplicationUser user { get; set; }
        public List<ShoppingCartItemModel> CartItems { get; set; } = new List<ShoppingCartItemModel>();
        public List<ProductDetailModel> Products { get; set; } = new List<ProductDetailModel>();
    }
}

