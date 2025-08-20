namespace FoodHunter.Model
{
    public record CustomerListModel:BasePageModel
    {
        public CustomerListModel()
        {
            
        }
        public List<CustomerModel> Customers { get; set; } = new List<CustomerModel>();
    }
}
