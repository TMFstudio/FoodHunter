using Core;
using Core.Models;
using Microsoft.AspNetCore.Identity;


namespace Service.Interfaces
{
    public interface ICustomerService
    {
        Task<IPagedList<Customer>> GetUsersAsync(int pageIndex = 0, int pageSize = int.MaxValue);
        Task<ApplicationUser> GetCustomerById(string id);
        Task AddRoleAsync(RoleManager<IdentityRole> roleManager, string roleName);
        //Task<(IdentityResult Result, Guid? UserId)> CreateAsync(UserCreateViewModel model);
        //Task<UserEditViewModel?> GetForEditAsync(Guid id);
        //Task<IdentityResult> UpdateAsync(UserEditViewModel model);
        //Task<UserDetailsViewModel?> GetDetailsAsync(Guid id);
        //Task<IdentityResult> DeleteAsync(Guid id);
        //Task<UserRolesEditViewModel?> GetRolesForEditAsync(Guid userId);
        //Task<IdentityResult> UpdateRolesAsync(Guid userId, IEnumerable<Guid> selectedRoleIds);
    }
}
