using Product_Management_System.Models;

namespace Product_Management_System.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> FindId(int? id);
        Task<Product> Create(Product product);
        Task<Product> Update(Product product);
        Task<Product> Delete(Product product);
    }
}
