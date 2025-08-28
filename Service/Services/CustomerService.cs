using Core;
using Core.Models;
using Data.DataAccess;
using Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;

namespace Service.Services
{
    public class CustomerService : ICustomerService
    {
        private const int MaxPageSize = 100;
        private readonly IRepository<Customer> _customerRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly RoleManager<ApplicationUser> _roleManager;
        private readonly ApplicationDbContext _dbContext;
        public CustomerService(IRepository<Customer> customerRepository,
        UserManager<ApplicationUser> userManager,
        //RoleManager<ApplicationUser> roleManager,
        ApplicationDbContext dbContext)
        {
            _customerRepository = customerRepository;
            _userManager = userManager;
            //_roleManager = roleManager;
            _dbContext = dbContext;
        }
        // Returns a paged list of users with filter/search.
        // Uses normalized columns (index-friendly) where possible for best performance.
        public async Task<IPagedList<Customer>> GetUsersAsync(int pageIndex=0,int pageSize=int.MaxValue)
        {
            return await _customerRepository.GetAllPagedAsync(async query =>
            {
                 var u  = _userManager.Users.AsNoTracking();

                var total = await u.CountAsync();

                var items = u.Select(u => new Customer
                {CustomerId=u.Id,
                    Email = u.Email!,
                    UserName = u.UserName!,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    PhoneNumber = u.PhoneNumber,
                    EmailConfirmed = u.EmailConfirmed
                }).OrderBy(u => u.FirstName).ThenBy(u => u.LastName).ThenBy(u => u.Email);
;
                return items;
            }, pageIndex, pageSize: pageSize);
            
         
        }    
        public async Task<ApplicationUser> GetCustomerById(string id)
        {
          return await  _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);

        }
        public async Task AddRoleAsync(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                var result = await roleManager.CreateAsync(new IdentityRole(roleName));
                if (!result.Succeeded)
                {
                    throw new Exception($"Failed to create role '{roleName}': {string.Join(", ", result.Errors.Select(x => x.Description))}");
                }
            }
        }
        //// Loads user data for the Edit form (read-only).
        //public async Task<UserEditViewModel?> GetForEditAsync(Guid id)
        //{
        //    // AsNoTracking -> we don't need change tracking for display
        //    var user = await _userManager.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        //    if (user == null)
        //        return null;
        //    return new UserEditViewModel
        //    {
        //        Id = user.Id,
        //        FirstName = user.FirstName,
        //        LastName = user.LastName,
        //        Email = user.Email!,
        //        PhoneNumber = user.PhoneNumber,
        //        DateOfBirth = user.DateOfBirth,
        //        IsActive = user.IsActive,
        //        EmailConfirmed = user.EmailConfirmed,
        //        ConcurrencyStamp = user.ConcurrencyStamp // used for optimistic concurrency in Update
        //    };
        //}
        //// Updates a user with optimistic concurrency check via ConcurrencyStamp.
        //public async Task<IdentityResult> UpdateAsync(UserEditViewModel model)
        //{
        //    // ExecutionStrategy adds resiliency (automatic retries for transient SQL errors)
        //    var strategy = _dbContext.Database.CreateExecutionStrategy();
        //    return await strategy.ExecuteAsync<IdentityResult>(async () =>
        //    {
        //        await using var transaction = await _dbContext.Database.BeginTransactionAsync();
        //        try
        //        {
        //            var user = await _userManager.FindByIdAsync(model.Id.ToString());
        //            if (user == null)
        //            {
        //                await transaction.RollbackAsync();
        //                return IdentityResult.Failed(new IdentityError { Code = "NotFound", Description = "User not found." });
        //            }
        //            // Optimistic concurrency guard:
        //            // If stamp changed, someone else updated the record
        //            if (!string.Equals(user.ConcurrencyStamp, model.ConcurrencyStamp, StringComparison.Ordinal))
        //            {
        //                await transaction.RollbackAsync();
        //                return IdentityResult.Failed(new IdentityError
        //                {
        //                    Code = "ConcurrencyFailure",
        //                    Description = "This user was modified by another admin. Please reload and try again."
        //                });
        //            }
        //            // If email changed, update both Email & UserName (Identity will SaveChanges inside the transaction)
        //            if (!string.Equals(user.Email, model.Email, StringComparison.OrdinalIgnoreCase))
        //            {
        //                var emailResult = await _userManager.SetEmailAsync(user, model.Email.Trim());
        //                if (!emailResult.Succeeded)
        //                {
        //                    await transaction.RollbackAsync();
        //                    return emailResult;
        //                }
        //                var usernameResult = await _userManager.SetUserNameAsync(user, model.Email.Trim());
        //                if (!usernameResult.Succeeded)
        //                {
        //                    await transaction.RollbackAsync();
        //                    return usernameResult;
        //                }
        //            }
        //            // Update profile fields
        //            user.FirstName = model.FirstName.Trim();
        //            user.LastName = model.LastName?.Trim();
        //            user.PhoneNumber = model.PhoneNumber;
        //            user.DateOfBirth = model.DateOfBirth;
        //            user.IsActive = model.IsActive;
        //            user.EmailConfirmed = model.EmailConfirmed;
        //            user.ModifiedOn = DateTime.UtcNow;
        //            var update = await _userManager.UpdateAsync(user);
        //            if (!update.Succeeded)
        //            {
        //                await transaction.RollbackAsync();
        //                return update;
        //            }
        //            await transaction.CommitAsync();
        //            return IdentityResult.Success;
        //        }
        //        catch
        //        {
        //            await transaction.RollbackAsync();
        //            throw;
        //        }
        //    });
        //}
        //// Returns detailed view model including assigned roles.
        //public async Task<UserDetailsViewModel?> GetDetailsAsync(Guid id)
        //{
        //    // Read-only entity for display
        //    var user = await _userManager.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        //    if (user == null)
        //        return null;
        //    // Identity API requires the user entity for role lookup
        //    var roles = await _userManager.GetRolesAsync(user);
        //    return new UserDetailsViewModel
        //    {
        //        Id = user.Id,
        //        Email = user.Email!,
        //        UserName = user.UserName!,
        //        FirstName = user.FirstName,
        //        LastName = user.LastName,
        //        PhoneNumber = user.PhoneNumber,
        //        DateOfBirth = user.DateOfBirth,
        //        LastLogin = user.LastLogin,
        //        IsActive = user.IsActive,
        //        EmailConfirmed = user.EmailConfirmed,
        //        CreatedOn = user.CreatedOn,
        //        ModifiedOn = user.ModifiedOn,
        //        Roles = roles.OrderBy(r => r).ToList()
        //    };
        //}
        //// Deletes a user with a guard to prevent removing the last Admin.
        //public async Task<IdentityResult> DeleteAsync(Guid id)
        //{
        //    var strategy = _dbContext.Database.CreateExecutionStrategy();
        //    return await strategy.ExecuteAsync<IdentityResult>(async () =>
        //    {
        //        await using var transaction = await _dbContext.Database.BeginTransactionAsync();
        //        try
        //        {
        //            var user = await _userManager.FindByIdAsync(id.ToString());
        //            if (user == null)
        //            {
        //                await transaction.RollbackAsync();
        //                return IdentityResult.Failed(new IdentityError { Code = "NotFound", Description = "User not found." });
        //            }
        //            // Safety: block deleting the last "Admin"
        //            var adminRole = await _roleManager.FindByNameAsync("Admin");
        //            if (adminRole != null)
        //            {
        //                var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
        //                if (isAdmin)
        //                {
        //                    var anotherAdminExists = await _dbContext.Set<IdentityUserRole<Guid>>()
        //                    .AnyAsync(ur => ur.RoleId == adminRole.Id && ur.UserId != user.Id);
        //                    if (!anotherAdminExists)
        //                    {
        //                        await transaction.RollbackAsync();
        //                        return IdentityResult.Failed(new IdentityError
        //                        {
        //                            Code = "LastAdmin",
        //                            Description = "You cannot delete the last user in the 'Admin' role."
        //                        });
        //                    }
        //                }
        //            }
        //            var delete = await _userManager.DeleteAsync(user);
        //            if (!delete.Succeeded)
        //            {
        //                await transaction.RollbackAsync();
        //                return delete;
        //            }
        //            await transaction.CommitAsync();
        //            return IdentityResult.Success;
        //        }
        //        catch
        //        {
        //            await transaction.RollbackAsync();
        //            throw;
        //        }
        //    });
        //}
        //// Builds the roles editor (checkbox list) with pre-checked assignments.
        //public async Task<UserRolesEditViewModel?> GetRolesForEditAsync(Guid userId)
        //{
        //    var user = await _userManager.FindByIdAsync(userId.ToString());
        //    if (user == null)
        //        return null;
        //    // List all active roles (read-only)
        //    var allRoles = await _roleManager.Roles
        //    .AsNoTracking()
        //    .OrderBy(r => r.Name)
        //    .Where(r => r.IsActive)
        //    .ToListAsync();
        //    // Current assignments for the user
        //    var assignedRoles = await _userManager.GetRolesAsync(user);
        //    // Case-insensitive check to avoid surprises with different normalizations
        //    var userRolesEditViewModel = new UserRolesEditViewModel
        //    {
        //        UserId = user.Id,
        //        UserName = user.UserName!,
        //        Roles = allRoles.Select(role => new RoleCheckboxItem
        //        {
        //            RoleId = role.Id,
        //            RoleName = role.Name!,
        //            Description = role.Description,
        //            IsSelected = assignedRoles.Contains(role.Name!, StringComparer.OrdinalIgnoreCase)
        //        }).ToList()
        //    };
        //    return userRolesEditViewModel;
        //}
        //// Updates a user's roles using batched operations
        //public async Task<IdentityResult> UpdateRolesAsync(Guid userId, IEnumerable<Guid> selectedRoleIds)
        //{
        //    var strategy = _dbContext.Database.CreateExecutionStrategy();
        //    return await strategy.ExecuteAsync<IdentityResult>(async () =>
        //    {
        //        await using var transaction = await _dbContext.Database.BeginTransactionAsync();
        //        try
        //        {
        //            var user = await _userManager.FindByIdAsync(userId.ToString());
        //            if (user == null)
        //            {
        //                await transaction.RollbackAsync();
        //                return IdentityResult.Failed(new IdentityError { Code = "NotFound", Description = "User not found." });
        //            }
        //            // Normalize and de-duplicate incoming IDs
        //            var ids = (selectedRoleIds ?? Enumerable.Empty<Guid>()).Distinct().ToList();
        //            // Map ONLY requested IDs -> names (read-only)
        //            var selectedRoleNames = (ids.Count == 0)
        //            ? new List<string>()
        //            : await _roleManager.Roles
        //            .AsNoTracking()
        //            .Where(r => ids.Contains(r.Id))
        //            .Select(r => r.Name!)
        //            .ToListAsync();
        //            // Validate existence
        //            if (selectedRoleNames.Count != ids.Count)
        //            {
        //                await transaction.RollbackAsync();
        //                return IdentityResult.Failed(new IdentityError
        //                {
        //                    Code = "RoleNotFound",
        //                    Description = "One or more selected roles do not exist."
        //                });
        //            }
        //            // Current roles
        //            var currentRoles = await _userManager.GetRolesAsync(user);
        //            // Compute diffs (case-insensitive)
        //            var current = new HashSet<string>(currentRoles, StringComparer.OrdinalIgnoreCase);
        //            var target = new HashSet<string>(selectedRoleNames, StringComparer.OrdinalIgnoreCase);
        //            //current: Admin Manager User
        //            //target: Admin Manager CustomerSupport Vendor
        //            var toAdd = target.Except(current, StringComparer.OrdinalIgnoreCase).ToList();
        //            //toAdd = CustomerSupport Vendor
        //            var toRemove = current.Except(target, StringComparer.OrdinalIgnoreCase).ToList();
        //            //toRemove = User
        //            if (toAdd.Count() == 0 && toRemove.Count() == 0)
        //            {
        //                await transaction.CommitAsync(); // nothing to do
        //                return IdentityResult.Success;
        //            }
        //            // Batch add/remove to minimize round-trips; both inside the same transaction
        //            if (toAdd.Count() > 0)
        //            {
        //                var add = await _userManager.AddToRolesAsync(user, toAdd);
        //                if (!add.Succeeded)
        //                {
        //                    await transaction.RollbackAsync();
        //                    return add;
        //                }
        //            }
        //            if (toRemove.Count() > 0)
        //            {
        //                var rem = await _userManager.RemoveFromRolesAsync(user, toRemove);
        //                if (!rem.Succeeded)
        //                {
        //                    await transaction.RollbackAsync();
        //                    return rem;
        //                }
        //            }
        //            await transaction.CommitAsync();
        //            return IdentityResult.Success;
        //        }
        //        catch
        //        {
        //            await transaction.RollbackAsync();
        //            throw;
        //        }
        //    });
        //}
    }
}