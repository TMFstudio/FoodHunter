
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductsCategories { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
                 // Customize the ASP.NET Identity model and override the defaults if needed.
                 // For example, you can rename the ASP.NET Identity table names and more.
                 // Add your customizations after calling base.OnModelCreating(builder);
            modelBuilder.Entity<ProductCategory>()
                                  .HasKey(x => x.Id);
            modelBuilder.Entity<ProductCategory>()
                                 .HasOne(x => x.Category)
                                 .WithMany(x => x.ProductCategory)
                                 .HasForeignKey(x => x.CategoryId);
            modelBuilder.Entity<ProductCategory>()
                                 .HasOne(x => x.Product)
                                 .WithMany(x => x.ProductCategory)
                                 .HasForeignKey(x => x.ProductId);

        }
    }
}
