using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Product_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Management_System.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Ensuring roles exist
            string[] roles = { "admin", "staff" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Default Staff Members to test
            if (!userManager.Users.Any(u => u.Email.Contains("staff")))
            {
                List<ApplicationUser> staffUsers = new List<ApplicationUser>
                {
                    new ApplicationUser { UserName = "staff1", Email = "staff1@example.com", FirstName = "John", LastName = "Doe", Address = "123 Street", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff2", Email = "staff2@example.com", FirstName = "Jane", LastName = "Smith", Address = "456 Avenue", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff3", Email = "staff3@example.com", FirstName = "Mike", LastName = "Brown", Address = "789 Road", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff4", Email = "staff4@example.com", FirstName = "Sara", LastName = "Connor", Address = "101 Blvd", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff5", Email = "staff5@example.com", FirstName = "David", LastName = "Johnson", Address = "202 Lane", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff6", Email = "staff6@example.com", FirstName = "Emily", LastName = "Clark", Address = "303 Hill", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff7", Email = "staff7@example.com", FirstName = "Robert", LastName = "White", Address = "404 Street", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff8", Email = "staff8@example.com", FirstName = "Olivia", LastName = "Harris", Address = "505 Avenue", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff9", Email = "staff9@example.com", FirstName = "William", LastName = "Martinez", Address = "606 Road", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff10", Email = "staff10@example.com", FirstName = "Sophia", LastName = "Lewis", Address = "707 Blvd", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff11", Email = "staff11@example.com", FirstName = "James", LastName = "Walker", Address = "808 Lane", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff12", Email = "staff12@example.com", FirstName = "Charlotte", LastName = "Hall", Address = "909 Drive", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff13", Email = "staff13@example.com", FirstName = "Benjamin", LastName = "Allen", Address = "1010 Street", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff14", Email = "staff14@example.com", FirstName = "Mia", LastName = "Young", Address = "1111 Avenue", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff15", Email = "staff15@example.com", FirstName = "Lucas", LastName = "King", Address = "1212 Road", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff16", Email = "staff16@example.com", FirstName = "Ella", LastName = "Scott", Address = "1313 Blvd", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff17", Email = "staff17@example.com", FirstName = "Henry", LastName = "Green", Address = "1414 Lane", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff18", Email = "staff18@example.com", FirstName = "Amelia", LastName = "Adams", Address = "1515 Drive", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff19", Email = "staff19@example.com", FirstName = "Daniel", LastName = "Nelson", Address = "1616 Street", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff20", Email = "staff20@example.com", FirstName = "Avery", LastName = "Baker", Address = "1717 Avenue", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff21", Email = "staff21@example.com", FirstName = "Sebastian", LastName = "Carter", Address = "1818 Road", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff22", Email = "staff22@example.com", FirstName = "Harper", LastName = "Mitchell", Address = "1919 Blvd", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff23", Email = "staff23@example.com", FirstName = "Jack", LastName = "Perez", Address = "2020 Lane", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff24", Email = "staff24@example.com", FirstName = "Lily", LastName = "Roberts", Address = "2121 Drive", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff25", Email = "staff25@example.com", FirstName = "Owen", LastName = "Turner", Address = "2222 Street", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff26", Email = "staff26@example.com", FirstName = "Evelyn", LastName = "Phillips", Address = "2323 Avenue", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff27", Email = "staff27@example.com", FirstName = "Leo", LastName = "Campbell", Address = "2424 Road", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff28", Email = "staff28@example.com", FirstName = "Scarlett", LastName = "Evans", Address = "2525 Blvd", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff29", Email = "staff29@example.com", FirstName = "Matthew", LastName = "Edwards", Address = "2626 Lane", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff30", Email = "staff30@example.com", FirstName = "Aria", LastName = "Collins", Address = "2727 Drive", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff31", Email = "staff31@example.com", FirstName = "Ryan", LastName = "Stewart", Address = "2828 Street", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff32", Email = "staff32@example.com", FirstName = "Grace", LastName = "Morris", Address = "2929 Avenue", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff33", Email = "staff33@example.com", FirstName = "Carter", LastName = "Rogers", Address = "3030 Road", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff34", Email = "staff34@example.com", FirstName = "Luna", LastName = "Reed", Address = "3131 Blvd", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff35", Email = "staff35@example.com", FirstName = "Nathan", LastName = "Cook", Address = "3232 Lane", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff36", Email = "staff36@example.com", FirstName = "Hannah", LastName = "Morgan", Address = "3333 Drive", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff37", Email = "staff37@example.com", FirstName = "Dylan", LastName = "Bell", Address = "3434 Street", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff38", Email = "staff38@example.com", FirstName = "Zoe", LastName = "Murphy", Address = "3535 Avenue", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff39", Email = "staff39@example.com", FirstName = "Eli", LastName = "Bailey", Address = "3636 Road", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff40", Email = "staff40@example.com", FirstName = "Mila", LastName = "Rivera", Address = "3737 Blvd", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff41", Email = "staff41@example.com", FirstName = "Jackson", LastName = "Cooper", Address = "3838 Lane", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff42", Email = "staff42@example.com", FirstName = "Penelope", LastName = "Richardson", Address = "3939 Drive", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff43", Email = "staff43@example.com", FirstName = "Isaac", LastName = "Howard", Address = "4040 Street", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff44", Email = "staff44@example.com", FirstName = "Sophie", LastName = "Ward", Address = "4141 Avenue", CreatedAt = DateTime.Now },
                    new ApplicationUser { UserName = "staff45", Email = "staff45@example.com", FirstName = "Anthony", LastName = "Torres", Address = "4242 Road", CreatedAt = DateTime.Now },
                };

                foreach (var user in staffUsers)
                {
                    var existingUser = await userManager.FindByEmailAsync(user.Email);
                    if (existingUser == null)
                    {
                        await userManager.CreateAsync(user, "Staff@123"); // Default password
                        await userManager.AddToRoleAsync(user, "Staff");
                    }
                }
            }
        }
    }
}
