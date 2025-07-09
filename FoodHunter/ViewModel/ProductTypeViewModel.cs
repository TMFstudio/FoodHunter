using System.ComponentModel.DataAnnotations;

namespace FoodHunter.ViewModel
{
    public record ProductTypeViewModel: BaseViewModel
    {
        [Required(ErrorMessage ="this filed should not be empty")]
        public string Name { get; set; }
    }
}