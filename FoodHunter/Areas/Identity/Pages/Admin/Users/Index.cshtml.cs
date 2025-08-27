using Core.Models;
using FoodHunter.Mapper;
using FoodHunter.Model;
using FoodHunter.Pages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interfaces;

namespace FoodHunter.Areas.Identity.Pages.Admin.Users
{
    [Authorize(Roles = "admin,owner")]
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICustomerService _customerService;

        public CustomerListModel Customers { get; set; } = new CustomerListModel();
        public IndexModel(UserManager<ApplicationUser> userManager, ICustomerService customerService)
        {
            this._userManager = userManager;
            this._customerService = customerService;
        }
        public async Task<IActionResult> OnGetAsync(int pageIndex)
        {
            var users = await _customerService.GetUsersAsync(pageIndex: pageIndex - 1, pageSize: 6);
            Customers.Customers = users.Select(x =>
            {
                var m = x.ToModel();
                return m;
            }).ToList();
            return Page();
        }
    }
}
