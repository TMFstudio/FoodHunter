using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodHunter.Model
{
    public record CustomerRoleModel: BaseModel
    {
        public CustomerModel? Customer { get; set; }
        public IList<SelectListItem>? CurrentRole { get; set; }=new List<SelectListItem>();
        public string? RoleName { get; set; }
        public IList<SelectListItem>? Roles { get; set; } = new List<SelectListItem>();

    }
}
