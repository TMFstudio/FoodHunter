using Core.Models;

namespace FoodHunter.Model
{
    public record OrderDetailModel:BaseModel
    {
        public IEnumerable<OrderItemModel> OrderItems { get; set; }
        public OrderModel Order { get; set; }
        public string? CustomerName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

    }
}
