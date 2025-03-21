using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Product_Management_System.Models;

namespace Product_Management_System.Data
{
    public class PmsDbContext : IdentityDbContext<ApplicationUser>
    {
        public PmsDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var adminRole = new IdentityRole("admin")
            {
                Id = "e9a1b6c4-7f6b-49f0-a5e5-ceddb46e5c2b",
                Name = "admin",
                NormalizedName = "ADMIN"
            };

            var staffRole = new IdentityRole("staff")
            {
                Id = "c3f47a63-92c4-432f-8146-6cdb54e4f4e2",
                Name = "staff",
                NormalizedName = "STAFF"
            };

            builder.Entity<IdentityRole>().HasData(adminRole, staffRole);
       
        }
    }
}
