using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Order:BaseEntity
    {
        public int Count { get; set; }
        public string? Address { get; set; }
        //enum
        public string? status { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser Customer { get; set; }
        public Product Product { get; set; }
        public DateTime? CreateOn { get; set; }
    }
}
