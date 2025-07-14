using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace FoodHunter.ViewModel
{
    public record ProductViewModel : BaseViewModel
    {
        public ProductViewModel()
        {
            ProductType = new List<SelectListItem>();

        }
        [BindProperty]
        [Required(ErrorMessage = "the name should not be empty")]
        public string Name { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "the name should not be empty")]
        public string Description { get; set; }
        [BindProperty]
        public int ProductTypeId { get; set; }
        [Required(ErrorMessage = "the name should not be empty")]
        [BindProperty]
        public string CreateDate { get; set; }
        [BindProperty]
        public string? ProductTypeName { get; set; }
        [BindProperty]
        public IList<SelectListItem>? ProductType { get; set; }
        [BindProperty]
        public int DisplayOrder { get; set; }

    }
}