using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Models
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            await InitializeCredits(serviceProvider);
            await InitializeRoles(serviceProvider);
        }

        private static async Task InitializeRoles(
            IServiceProvider serviceProvider)
        {
            using (var context = new CreditContext(
                       serviceProvider.GetRequiredService<
                           DbContextOptions<CreditContext>>()))
            {
                var UserManager = serviceProvider
                    .GetRequiredService<UserManager<IdentityUser>>();
                var RoleManager = serviceProvider
                    .GetRequiredService<RoleManager<IdentityRole>>();
                string[] roleNames = {"admin", "manager"};
                IdentityResult roleResult;

                foreach (var roleName in roleNames)
                {
                    var roleExist = await RoleManager.RoleExistsAsync(roleName);
                    if (!roleExist)
                    {
                        roleResult =
                            await RoleManager.CreateAsync(
                                new IdentityRole(roleName));
                    }
                }

                var email = "admin@example.ru";
                string userPWD = "Pa$sw0rd!";
                var user = new IdentityUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };
                var existingUser = await UserManager.FindByEmailAsync(email);

                if (existingUser == null)
                {
                    var createPowerUser =
                        await UserManager.CreateAsync(user, userPWD);
                    if (createPowerUser.Succeeded)
                    {
                        await UserManager.AddToRoleAsync(user, "admin");
                        await UserManager.AddToRoleAsync(user, "user");
                    }
                }
            }
        }

        private static Task InitializeCredits(IServiceProvider serviceProvider)
        {
            using (var context = new CreditContext(serviceProvider
                       .GetRequiredService<DbContextOptions<CreditContext>>()))
            {
                // Look for any movies.
                if (context.Credits.Any() || context.Bids.Any())
                {
                    return Task.CompletedTask;
                }

                context.Credits.Add(new Credit
                {
                    Head = "Ипотечный кредит", Period = 10, Sum = 1000000,
                    Procent = 15
                });
                context.Credits.Add(new Credit
                {
                    Head = "Образовательный кредит", Period = 7, Sum = 300000,
                    Procent = 10
                });
                context.Credits.Add(new Credit
                {
                    Head = "Потребительский кредит", Period = 5, Sum = 500000,
                    Procent = 19
                });
                context.SaveChanges();
            }

            return Task.CompletedTask;
        }
    }
}