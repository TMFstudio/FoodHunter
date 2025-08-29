namespace FoodHunter.Model
{
    public record DashboardModel:BaseModel
    {
        public List<OrderModel> Orders { get; set; } = new List<OrderModel>();
        public List<ProductModel> Products { get; set; } = new List<ProductModel>();
        public List<CustomerModel> Customers { get; set; } = new List<CustomerModel>();

        public int? ToDayOrderCount{ get; set; }
        public double? ToDayOrderTotal{ get; set; }
    }
}
