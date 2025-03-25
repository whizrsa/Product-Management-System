using Microsoft.AspNetCore.Identity;
using Product_Management_System.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Management_System.Services
{
    public class StaffService : IStaffService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public StaffService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllStaff(string searchString)
        {
            var users = await _userManager.GetUsersInRoleAsync("staff");

            if (!string.IsNullOrEmpty(searchString))
            {
                users = users.Where(u => u.FirstName.Contains(searchString) || u.LastName.Contains(searchString) || u.Email.Contains(searchString)).ToList();
            }

            return users;
        }

        public async Task<ApplicationUser> FindById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<ApplicationUser> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
            return user;
        }
    }
}
