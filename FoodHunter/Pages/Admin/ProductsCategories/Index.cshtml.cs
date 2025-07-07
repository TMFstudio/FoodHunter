using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace FoodHunter.Pages.Admin.ProductsCategories
{
    public class IndexModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public IndexModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ProductsCategory> ProductsCategory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ProductsCategory = await _context.ProductsCategories
                .Include(p => p.Category)
                .Include(p => p.Product).ToListAsync();
        }
    }
}
