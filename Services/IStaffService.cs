using Product_Management_System.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product_Management_System.Services
{
    public interface IStaffService
    {
        Task<IEnumerable<ApplicationUser>> GetAllStaff(string searchString);
        Task<ApplicationUser> FindById(string id);
        Task<ApplicationUser> Delete(string id);
    }
}
