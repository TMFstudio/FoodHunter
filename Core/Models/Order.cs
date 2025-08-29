using Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Core.Models
{
    public class Order : BaseEntity
    {
        public int Count { get; set; }
        [Required]
        public string? Address { get; set; }
        public string? CustomerId { get; set; }
        public int? StatusId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser Customer { get; set; }

        public DateTime OrderDate { get; set; }
        [Required]
        public DateTime PickUpTime { get; set; }
        public double OrderTotal { get; set; }
        public string? TransactionId { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? PickUpName { get; set; }
    }
}
