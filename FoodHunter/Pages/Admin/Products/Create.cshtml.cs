
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interfaces;
using FoodHunter.Mapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using FoodHunter.Model;
using Core.Models;
using Service.Services;


namespace FoodHunter.Pages.Admin.Products
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IProductTypeService _productTypeService;
        private readonly IWebHostEnvironment _hostEnvironment;
        public ProductModel Product { get; set; } = default!;


        public CreateModel(IProductService productService,
            IWebHostEnvironment hostEnvironment,
            IProductTypeService productTypeService)
        {
            _hostEnvironment = hostEnvironment;
            _productService = productService;
            _productTypeService = productTypeService;
        }

        protected virtual async Task PrepareProductCategory()
        {
            var products = await _productTypeService.GetAllProductTypesAsync();
            Product = new ProductModel
            {
                ProductType = products.Select(item => new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                }).ToList()
            };
        }

        public async Task<IActionResult> OnGet()
        {
          await  PrepareProductCategory();
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                   if( Product.Image!=null)
                    {
                        //Create
                        string fileName = Guid.NewGuid().ToString();
                        var uploads = Path.Combine(webRootPath, @"images\ProductItems");
                        var extenstion = Path.GetExtension(files[0].FileName);
                        using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extenstion), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }
                        Product.Image = @"\images\product\" + fileName + extenstion;
                    }                   
                   var entity= Product.ToEntity();
                   await _productService.InsertProductAsync(entity);
                    return RedirectToPage("Index");
            }

          await  PrepareProductCategory();
            return Page();
        }
    }
}
