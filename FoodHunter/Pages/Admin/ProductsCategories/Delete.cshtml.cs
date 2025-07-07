using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Core.Models;
using Data;

namespace FoodHunter.Pages.Admin.ProductsCategories
{
    public class DeleteModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public DeleteModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProductsCategory ProductsCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productscategory = await _context.ProductsCategories.FirstOrDefaultAsync(m => m.Id == id);

            if (productscategory == null)
            {
                return NotFound();
            }
            else
            {
                ProductsCategory = productscategory;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productscategory = await _context.ProductsCategories.FindAsync(id);
            if (productscategory != null)
            {
                ProductsCategory = productscategory;
                _context.ProductsCategories.Remove(ProductsCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
