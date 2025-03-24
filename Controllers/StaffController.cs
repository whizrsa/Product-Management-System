using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product_Management_System.Models;
using Product_Management_System.Services;
using System.Threading.Tasks;

namespace Product_Management_System.Controllers
{
    [Authorize(Roles = "admin")]
    public class StaffController : Controller
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var staffList = await _staffService.GetAllStaff(searchString);
            ViewData["CurrentFilter"] = searchString;
            return View(staffList);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var staffMember = await _staffService.Delete(id);
            if (staffMember == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
