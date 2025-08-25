namespace FoodHunter.Model
{
    public record OrderListModel : BaseModel
    {
        public IEnumerable<OrderModel> Orders { get; set; } = new List<OrderModel>();
    }
}
