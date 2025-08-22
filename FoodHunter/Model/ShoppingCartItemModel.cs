using Core.Models;
using System.ComponentModel.DataAnnotations;

namespace FoodHunter.Model
{
    public record ShoppingCartItemModel:BaseModel
    {
        public ShoppingCartItemModel()
        {
        }
        [Range(1,100,ErrorMessage ="pls select beatween of 1 - 100")]
        public int ItemsCount { get; set; }
        public int? ProductId  { get; set; }
        public DateTime? CreateOn  { get; set; }
        public ProductDetailModel? Product { get; set; } = new ProductDetailModel();   
        public string? CustomerId  { get; set; }
        public ApplicationUser? Customer { get; set; }= new ApplicationUser();
    }
}
