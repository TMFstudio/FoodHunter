using Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodHunter.ViewModel
{
    public class ProductViewModel : BaseViewModel
    {
        public ProductViewModel()
        {
            ProductType=new ProductType();
            ProductsCategory = new ProductsCategory();
        }
        public int ProductTypeId { get; set; }
        [Required(ErrorMessage = "the name should not be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "the name should not be empty")]
        public string Description { get; set; }
        [Required(ErrorMessage = "the name should not be empty")]
        public string CreateDate { get; set; }
        public int DisplayOrder { get; set; }
        public ProductType ProductType { get; set; }

        public ProductsCategory ProductsCategory { get; set; }
    }
}