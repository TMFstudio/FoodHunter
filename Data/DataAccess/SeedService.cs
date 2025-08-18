using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Data.DataAccess
{
    public class SeedService
    {
        public static async Task SeedDatabase(IServiceProvider serviceProvider)
        {
                using var scope = serviceProvider.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<SeedService>>();

                try
                {
                    logger.LogInformation("Ensure data base is Create");
                    await context.Database.EnsureCreatedAsync();

                    //Seeding roles
                    logger.LogInformation("Seeding roles");
                    await AddRoleAsync(roleManager, "owner");
                    await AddRoleAsync(roleManager, "admin");
                    await AddRoleAsync(roleManager, "client");

                    //Seeding First owner User
                    logger.LogInformation("Seeding Defult owner role");
                    var adminEmail = "adminFarbod@gmail.com";
                    if (await userManager.FindByEmailAsync(adminEmail) == null)
                    {
                        var adminuser = new ApplicationUser
                        {
                            FirstName = "farbod",
                            LastName = "alikhani",
                            UserName = adminEmail,
                            Email = adminEmail,
                            NormalizedEmail = adminEmail.ToUpper(),
                            EmailConfirmed = true,
                            SecurityStamp = Guid.NewGuid().ToString(),
                        };
                        var result = await userManager.CreateAsync(adminuser, "Admin@123");
                        if (result.Succeeded)
                        {
                            logger.LogInformation("Assigning Admin Role to the User");
                            await userManager.AddToRoleAsync(adminuser, "owner");

                        }
                        else
                        {
                            logger.LogError("Faild to create admin user :{Error}", string.Join(", ", result.Errors.Select(e => e.Description)));
                        }

                    }

                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "an error occurred while seeding the database.");
                }
            }
       
        private static async Task AddRoleAsync(RoleManager<IdentityRole> roleManager,string roleName)
        {
            if(!await roleManager.RoleExistsAsync(roleName))
            {
                var result = await roleManager.CreateAsync(new IdentityRole(roleName));
                if (!result.Succeeded) 
                {
                    throw new Exception($"Failed to create role '{roleName}': {string.Join(", ", result.Errors.Select(x => x.Description))}");
                }
            }
        }
    }
}
