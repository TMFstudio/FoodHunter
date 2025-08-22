using Data;
using System.ComponentModel.DataAnnotations.Schema;


namespace Core.Models
{
    public class ShoppingCart: BaseEntity
    {
        public int Count { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public DateTime? CreateOn { get; set; }
    }
}
