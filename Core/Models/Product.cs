

using Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class Product: BaseEntity
    {

        public int ProductTypeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string CreateDate { get; set; }
        public string? Image { get; set; }
        public double Price { get; set; }
        public int DisplayOrder { get; set; }
        [ForeignKey("ProductTypeId")]
        public ProductType ProductType { get; set; }

        public ProductCategory ProductCategory { get; set; }
    }
}
