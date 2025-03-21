using Microsoft.AspNetCore.Mvc;
using Product_Management_System.Data;

namespace Product_Management_System.Controllers
{
    public class ProductController : Controller
    {
        private readonly PmsDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public ProductController(PmsDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
