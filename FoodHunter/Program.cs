using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;
using Service.Services;
using Microsoft.AspNetCore.Identity;
using Core.Models;
using Data.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<Data.DataAccess.ApplicationDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
{
    option.Password.RequireDigit = true;
    option.Password.RequireLowercase = true;
    option.Password.RequiredLength = 6;
    //option.User.RequireUniqueEmail = true;
    option.SignIn.RequireConfirmedPhoneNumber = false;
    option.SignIn.RequireConfirmedEmail = false;
    option.SignIn.RequireConfirmedAccount = false;
}).AddEntityFrameworkStores<Data.DataAccess.ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductTypeService, ProductTypeService>();
builder.Services.AddTransient<IProductsCategoriesService, ProductsCategoriesService>();

var app = builder.Build();

await SeedService.SeedDatabase(app.Services);
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
