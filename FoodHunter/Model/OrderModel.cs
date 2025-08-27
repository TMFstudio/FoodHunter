

namespace FoodHunter.Model
{
    public record OrderModel :BaseModel
    {
        public int Count { get; set; }
        public string? Address { get; set; }
        public string? CustomerId { get; set; }
        public string? Status { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime PickUpTime { get; set; }
        public double OrderTotal { get; set; }
        public string? TransactionId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PickUpName { get; set; }
        public string? CustomerName { get; set; }

    }
}
