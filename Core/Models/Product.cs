

using Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class Product: BaseEntity
    {

        [ForeignKey("ProudctType")]
        public int ProductTypeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string CreateDate { get; set; }
        public int DisplayOrder { get; set; }
        public ProductType ProductType { get; set; }

        public ProductCategory ProductCategory { get; set; }
    }
}
