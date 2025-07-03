using Core.Models;
using FoodHunter.ViewModel;

namespace FoodHunter.Mapper
{
    public static class Mapper
    {
        #region Category
        public static CategoryViewModel ToViewModel(this Category category)
        {
            return new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                DisplayOrder = category.DisplayOrder
            };
        }

        public static List<CategoryViewModel> ToViewModelList(this IEnumerable<Category> category)
        {
           return category.Select(x=>x.ToViewModel()).ToList();
        }
        public static Category ToEntity(this CategoryViewModel category)
        {
            return new Category
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                DisplayOrder = category.DisplayOrder
            };
        }
        #endregion
    }
}
