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

        public ProductController(IProductService productService)
        {
            _productService = productService;
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
        public async Task<IActionResult> Create(ProductDto productDto)
        {

            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    ProductName = productDto.ProductName,
                    ProductDescription = productDto.ProductDescription,
                    Price = productDto.Price,
                    ImageFileName = productDto.ImageFile,
                    IsActive = productDto.IsActive
                };
                await _productService.Create(product);
                return RedirectToAction("Index", "Product");
            }
            return View(productDto);
        }
    }
}
