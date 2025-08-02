using Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodHunter.Model
{
    public record ProductCategoryModel : BaseModel
    {
        public ProductCategoryModel()
        {
            Category= new List<SelectListItem>();
            Product= new List<SelectListItem>();

        }
        public int CategoryId { get; set; }
        public IList<SelectListItem>? Category { get; set; }
        public int ProductId { get; set; }
        public IList<SelectListItem>? Product { get; set; }

    }
}
