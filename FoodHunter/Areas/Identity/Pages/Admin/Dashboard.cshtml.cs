using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodHunter.Areas.Identity.Pages.Admin
{
    [Authorize(Roles = "admin,owner")]
    public class Index1Model : PageModel
    {
        public void OnGet()
        {
        }
    }
}
