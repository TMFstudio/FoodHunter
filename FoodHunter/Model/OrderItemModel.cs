

namespace FoodHunter.Model
{
    public record OrderItemModel:BaseModel
    {
        public int ProductId { get; set; }
        public int OrderID { get; set; }
        public int Count { get; set; }
        public double? Price { get; set; }
        public string Name { get; set; }

    }
}
