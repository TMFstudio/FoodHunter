using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Core.Models;
using Data;

namespace FoodHunter.Pages.Admin.ProductsType
{
    public class IndexModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public IndexModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ProductType> ProductType { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ProductType = await _context.ProductTypes.ToListAsync();
        }
    }
}
