using Microsoft.EntityFrameworkCore;
using Product_Management_System.Data;
using Product_Management_System.Models;

namespace Product_Management_System.Services
{
    public class ProductService : IProductService
    {
        private readonly PmsDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ProductService(PmsDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Product> Create(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> Delete(Product product)
        {
            var findProduct = _context.Products.FindAsync(product.Id);

            if(findProduct == null)
            {
                return null;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> FindId(int? id)
        {
            var productId = await _context.Products.FindAsync(id);

            if (productId == null)
            {
                return null;
            }

            return productId;
        }

        public async Task<Product> Update(Product product)
        {
            var existingProduct = _context.Products.FindAsync(product.Id);

            if(existingProduct == null)
            {
                return null;
            }

            _context.Entry(existingProduct).CurrentValues.SetValues(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
