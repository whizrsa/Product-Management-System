using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product_Management_System.Data;
using Product_Management_System.Dto;
using Product_Management_System.Models;
using Product_Management_System.Services;

namespace Product_Management_System.Controllers
{
    [Authorize(Roles = "admin,staff")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _hostingEnvironment;  // Inject IWebHostEnvironment

        public ProductController(IProductService productService, IWebHostEnvironment hostingEnvironment)
        {
            _productService = productService;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;

            var products = await _productService.GetAll(sortOrder, searchString);
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

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

                // Product object
                var product = new Product
                {
                    ProductName = productDto.ProductName,
                    ProductDescription = productDto.ProductDescription,
                    Price = productDto.Price,
                    ImageFileName = uniqueFileName,
                    IsActive = productDto.IsActive
                };

                await _productService.Create(product);
                return RedirectToAction("Index", "Product");
            }

            return View(productDto);
        }

        public async Task<IActionResult> Edit(int? productId)
        {
            if (productId == null)
            {
                return NotFound();
            }

            var product = await _productService.FindId(productId);

            if (product == null)
            {
                return NotFound();
            }

            //create productDto object from product
            var productDto = new ProductDto
            {
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                Price = product.Price,
                IsActive = product.IsActive
            };

            ViewData["ImageFileName"] = product.ImageFileName;
            ViewData["ProductId"] = productId;
            ViewData["DateAdded"] = product.DateAdded;


            return View(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? productId, ProductDto productDto)
        {
            var product = await _productService.FindId(productId);

            if (product == null)
            {
                return RedirectToAction("Index","Product");
            }

            if(!ModelState.IsValid)
            {
                ViewData["ImageFileName"] = product.ImageFileName;
                ViewData["ProductId"] = productId;
                ViewData["DateAdded"] = product.DateAdded.ToString("yyyy-MM-dd");
                return View(productDto);
            }

            if (productDto.ImageFile != null)
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
                // Delete old image
                string oldFilePath = Path.Combine(uploadPath, product.ImageFileName);
                if (System.IO.File.Exists(oldFilePath))
                {
                    System.IO.File.Delete(oldFilePath);
                }
                product.ImageFileName = uniqueFileName;
            }

            //Update Product in the database
            product.ProductName = productDto.ProductName;
            product.ProductDescription = productDto.ProductDescription;
            product.Price = productDto.Price;
            product.IsActive = productDto.IsActive;
            product.ImageFileName = product.ImageFileName;

            await _productService.Update(product);
            return RedirectToAction("Index", "Product");

        }

        public async Task<IActionResult> Delete(int? productId)
        {
            if (productId == null)
            {
                return NotFound();
            }
            var product = await _productService.FindId(productId);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? productId, ProductDto productDto)
        {
            var product = await _productService.FindId(productId);
            if (product == null)
            {
                return RedirectToAction("Index", "Product");
            }
            // Delete image
            string uploadPath = Path.Combine(_hostingEnvironment.WebRootPath, "images");
            string filePath = Path.Combine(uploadPath, product.ImageFileName);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            await _productService.Delete(product);
            return RedirectToAction("Index", "Product");
        }
    }
}
