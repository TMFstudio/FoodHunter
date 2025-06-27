using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodHunter.ViewModel
{
    public partial class CategoryViewModel : BaseViewModel
    {
        public CategoryViewModel() { }
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="out of range 1-100 !")]
        public int DisplayOrder { get; set; }

    }
}
