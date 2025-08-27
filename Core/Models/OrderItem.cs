using Data;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Core.Models
{
    public class OrderItem : BaseEntity
    {
        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int OrderID { get; set; }
        [ForeignKey("OrderID")]
        public Order Order { get; set; }
        public int Count { get; set; }
        [Required]
        public double Price { get; set; }
        public string Name { get; set; }
    }
}
