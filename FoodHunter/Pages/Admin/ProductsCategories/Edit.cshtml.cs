using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Models;
using Data;

namespace FoodHunter.Pages.Admin.ProductsCategories
{
    public class EditModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public EditModel(Data.ApplicationDbContext context)
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

            var productscategory =  await _context.ProductsCategories.FirstOrDefaultAsync(m => m.Id == id);
            if (productscategory == null)
            {
                return NotFound();
            }
            ProductsCategory = productscategory;
           ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Description");
           ViewData["ProductId"] = new SelectList(_context.Products, "Id", "CreateDate");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ProductsCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsCategoryExists(ProductsCategory.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductsCategoryExists(int id)
        {
            return _context.ProductsCategories.Any(e => e.Id == id);
        }
    }
}
