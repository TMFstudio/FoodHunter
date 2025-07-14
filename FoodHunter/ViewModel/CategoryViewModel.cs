using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodHunter.ViewModel
{

    public partial record CategoryViewModel : BaseViewModel
    {
        [BindProperty]
        [Required(ErrorMessage = "the name should not be empty")]
        public string Name { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "the Description should not be empty")]
        public string Description { get; set; }
        [BindProperty]
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "out of range 1-100 !")]
        public int DisplayOrder { get; set; }

    }
}
