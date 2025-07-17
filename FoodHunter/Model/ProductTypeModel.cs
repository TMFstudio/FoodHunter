using System.ComponentModel.DataAnnotations;

namespace FoodHunter.Model
{
    public record ProductTypeModel: BaseModel
    {
        [Required(ErrorMessage ="this filed should not be empty")]
        public string Name { get; set; }
    }
}