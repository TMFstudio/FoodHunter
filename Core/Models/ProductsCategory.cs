
using Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class ProductCategory: BaseEntity
    {
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
