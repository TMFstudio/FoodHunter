
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FoodHunter.Mapper;
using Service.Interfaces;
using FoodHunter.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace FoodHunter.Pages.Admin.Products
{
    [BindProperties]
    [Authorize]
    public class UpdateModel : PageModel
    {
        private readonly IProductTypeService _productTypeService;
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public UpdateModel(IProductService productService, IProductTypeService productTypeService, IWebHostEnvironment hostEnvironment
)
        {
            _hostEnvironment = hostEnvironment;
            _productTypeService = productTypeService;
            _productService = productService;
        }
        public ProductModel Product { get; set; }
        protected virtual async Task PrepareProductCategory()
        {
            var products = await _productTypeService.GetAllProductTypesAsync();
            Product.ProductTypes = products.Select(item => new SelectListItem
            {
                Text = item.Name,
                Value = item.Id.ToString()
            }).ToList();

        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _productService.GetProductByIdAsync(id.Value);

            if (product == null)
            {
                return NotFound();
            }
            Product = product.ToModel();
            await PrepareProductCategory();



            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                if (files.Count != 0 && files != null)
                {
                    //Create
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\ProductItems");
                    var extenstion = Path.GetExtension(files[0].FileName);
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extenstion), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    Product.Image = @"\Images\ProductItems\" + fileName + extenstion;
                }
                var entity = Product.ToEntity();
                if (entity == null)
                {
                    return NotFound();
                }
                await _productService.UpdateProductAsync(entity);
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
