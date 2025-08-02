
using Data;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public partial class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }
        public ICollection<ProductCategory> ProductCategory { get; set; }

    }
}
