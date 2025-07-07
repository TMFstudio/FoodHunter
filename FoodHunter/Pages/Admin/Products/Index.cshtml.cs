using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Core.Models;
using Data;
using FoodHunter.ViewModel;
using FoodHunter.Mapper;

namespace FoodHunter.Pages.Admin.Products
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        public IEnumerable<ProductViewModel> Products { get; set; }

        public IndexModel(Data.ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task OnGetAsync()
        {
            //prepare
            Products = _dbContext.Products.ToViewModelList();
            

        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id != 0)
            {
                var entity = await _dbContext.Products.FindAsync(id);
                _dbContext.Products.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return RedirectToPage();
            }
            return RedirectToPage();
        }
    }
}
