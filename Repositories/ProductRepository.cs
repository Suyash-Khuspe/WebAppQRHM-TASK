using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using WebAppQRHM_TASK.Models;

namespace WebAppQRHM_TASK.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _dbconnection;

        public ProductRepository(IDbConnection dbConnection)
        {
            _dbconnection = dbConnection;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var query = "SELECT * FROM Product";
            return await _dbconnection.QueryAsync<Product>(query);
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var query = "SELECT * FROM Product WHERE id = @Id";
            return await _dbconnection.QueryFirstOrDefaultAsync<Product>(query, new { Id = id });
        }

        public async Task AddProductAsync(Product product)
        {
            var query = "INSERT INTO PRODUCT (Name, Description, Created) VALUES (@name, @description, GETDATE())";
            await _dbconnection.ExecuteAsync(query, product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            var query = "UPDATE PRODUCT SET Name=@name, Description=@description WHERE Id=@id";
            await _dbconnection.ExecuteAsync(query, product);
        }

        public async Task DeleteProductAsync(int id)
        {
            var query = "DELETE FROM Product where Id=@id";
            await _dbconnection.ExecuteAsync(query, new { Id = id });
        }
    }
}
