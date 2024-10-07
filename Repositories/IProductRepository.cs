using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppQRHM_TASK.Models;

namespace WebAppQRHM_TASK.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddProductAsync(Product Product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}
