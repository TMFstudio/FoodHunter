using Core.Models;

namespace FoodHunter.Model
{
    public record ProductsDetailModel:BaseModel
    {
        public int ProductTypeId { get; set; }
        public int? ProductCount { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Image { get; set; }
        public double Price { get; set; }
        public int DisplayOrder { get; set; }

        public string? ProductTypeName { get; set; }
        public List<Category> categories { get; set; }= new List<Category>();
    }
}
