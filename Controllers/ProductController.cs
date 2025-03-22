using Microsoft.AspNetCore.Mvc;
using Product_Management_System.Data;
using Product_Management_System.Dto;
using Product_Management_System.Models;
using Product_Management_System.Services;

namespace Product_Management_System.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _hostingEnvironment;  // Inject IWebHostEnvironment

        public ProductController(IProductService productService, IWebHostEnvironment hostingEnvironment)
        {
            _productService = productService;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAll();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            if (productDto.ImageFile == null || productDto.ImageFile.Length == 0)
            {
                ModelState.AddModelError("ImageFile", "The image file is required");
            }

            if (ModelState.IsValid)
            {
                // Save image
                string uniqueFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") +
                                        Path.GetExtension(productDto.ImageFile!.FileName);
                string uploadPath = Path.Combine(_hostingEnvironment.WebRootPath, "images");

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                string filePath = Path.Combine(uploadPath, uniqueFileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await productDto.ImageFile.CopyToAsync(stream);
                }

                // Create product object
                var product = new Product
                {
                    ProductName = productDto.ProductName,
                    ProductDescription = productDto.ProductDescription,
                    Price = productDto.Price,
                    ImageFileName = uniqueFileName,  // Store only the filename
                    IsActive = productDto.IsActive
                };

                await _productService.Create(product);
                return RedirectToAction("Index", "Product");
            }

            return View(productDto);
        }
    }
}
