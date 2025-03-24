using Microsoft.EntityFrameworkCore;
using Product_Management_System.Data;
using Product_Management_System.Models;

namespace Product_Management_System.Services
{
    public class ProductService : IProductService
    {
        private readonly PmsDbContext _context;

        public ProductService(PmsDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAll(string sortOrder,string searchString)
        {
            var products = from product in _context.Products
                           select product;

            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(product => product.ProductName.Contains(searchString));
            }

            switch(sortOrder)
            {
                case "name_desc":
                    products = products.OrderByDescending(product => product.ProductName);
                    break;
                case "Date":
                    products = products.OrderBy(product => product.DateAdded);
                    break;
                case "date_desc":
                    products = products.OrderByDescending(product => product.DateAdded);
                    break;
                default:
                    products = products.OrderBy(product => product.ProductName);
                    break;
            }

            return await products.AsNoTracking().ToListAsync();
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
            var existingProduct = await _context.Products.FindAsync(product.Id);

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

