using Microsoft.AspNetCore.Identity;
using Product_Management_System.Models;

namespace Product_Management_System.Data
{
    public class DataInitializer
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // Does role exists or not
            if (!await roleManager.RoleExistsAsync("admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }

            // Does emaileExist or not
            var adminUser = await userManager.FindByEmailAsync("elvischimuse@gmail.com");
            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    Id = "e9a1b6c4-7f6b-49f0-a5e5-ceddb46e5c2b",
                    UserName = "elvischimuse@gmail.com",
                    NormalizedUserName = "ELVISCHIMUSE@GMAIL.COM",
                    Email = "elvischimuse@gmail.com",
                    NormalizedEmail = "ELVISCHIMUSE@GMAIL.COM",
                    EmailConfirmed = true,
                    FirstName = "Elvis",
                    LastName = "Chimuse",
                    PhoneNumber = "045 546 6257",
                    Address = "56 DavenPort",
                    CreatedAt = DateTime.UtcNow,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };

                var result = await userManager.CreateAsync(adminUser, "EC@#200309$"); // Set a secure password here

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "admin");
                }
            }
        }
    }
}
