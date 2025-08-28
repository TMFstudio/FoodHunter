using Core.Models;
using FoodHunter.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using Service.Interfaces;

namespace FoodHunter.Areas.Identity.Pages.Admin.Users
{
    [Authorize(Roles = "admin,owner")]
    [BindProperties]
    public class RoleModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ICustomerService _customerService;

        public CustomerRoleModel CustomerRole { get; set; } = new CustomerRoleModel();
        public RoleModel(UserManager<ApplicationUser> userManager, ICustomerService customerService, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._customerService = customerService;
        }
        public async Task<IActionResult> OnGetAsync(string id)
        {
            var user = await _customerService.GetCustomerById(id);
            var roles = await _roleManager.Roles.ToListAsync();
            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var item in userRoles)
            {
                CustomerRole.CurrentRole.Add(new SelectListItem
                {
                    Text = item,
                    Value = item
                });
            }
            foreach (var item in roles)
            {
                CustomerRole.Roles.Add(new SelectListItem
                {
                    Text = item.NormalizedName,
                    Value = item.Name
                });
            }
            CustomerRole.Customer = new CustomerModel()
            {CustomerId=user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
            };
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (ModelState.IsValid)
            {
                var users = await _customerService.GetCustomerById(id);

                if (CustomerRole.RoleName != null)
                {
                    var resulet = await _userManager.AddToRoleAsync(users, CustomerRole.RoleName);
                }
                else
                    await _userManager.AddToRoleAsync(users, "client");
            }
            return RedirectToPage(routeValues: new { id });
        }
        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (ModelState.IsValid)
            {
                var users = await _customerService.GetCustomerById(id);
                if (CustomerRole.RoleName != null)
                    await _userManager.RemoveFromRoleAsync(users, CustomerRole.RoleName);  

            }
            return RedirectToPage(routeValues: new { id });
        }
    }
}
