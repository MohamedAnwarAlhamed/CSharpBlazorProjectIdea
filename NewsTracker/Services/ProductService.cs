using Dapper;
using NewsTracker.Model;
using System.Data;

namespace NewsTracker.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
    }
    public class ProductService : IProductService
    {
        private readonly IDbConnection _dbConnection;

        public ProductService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var sql = "SELECT Id, Name, ImageUrl, Price FROM Products";
            return (await _dbConnection.QueryAsync<Product>(sql)).ToList();
        }
    }
}
