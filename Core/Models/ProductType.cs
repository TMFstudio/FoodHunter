using Data;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class ProductType: BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}