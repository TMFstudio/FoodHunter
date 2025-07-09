using System.ComponentModel.DataAnnotations;

namespace Data
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}