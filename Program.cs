using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Product_Management_System.Data;
using Product_Management_System.Models;

namespace Product_Management_System;
public class Program
{
    public static async Task Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<PmsDbContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
        });

        builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<PmsDbContext>();

        var app = builder.Build();

        // Seed the database with roles and admin user
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                await DataInitializer.SeedRolesAndAdminAsync(services);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while seeding the database.");
            }
        }

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();


        app.MapStaticAssets();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.MapRazorPages();

        app.Run();
    }
}
