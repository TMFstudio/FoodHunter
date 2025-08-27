namespace FoodHunter.Model
{
    public record OrderListModel : BasePageModel
    {
        public IEnumerable<OrderModel> Orders { get; set; } = new List<OrderModel>();
    }
}
