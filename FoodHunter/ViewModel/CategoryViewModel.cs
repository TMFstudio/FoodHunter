using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodHunter.ViewModel
{

    public partial class CategoryViewModel : BaseViewModel
    {
        [BindProperty]
        [Required(ErrorMessage = "validation message")]
        public string Name { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "validation message")]
        public string Description { get; set; }
        [BindProperty]

        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "out of range 1-100 !")]
        public int DisplayOrder { get; set; }

    }
}
