using NewsTracker.Model;
using Dapper;
using Microsoft.Data.SqlClient; // Updated namespace
using System.Data;
namespace NewsTracker.Services
{
    public class NewsService
    {
        private readonly string _connectionString;

        public NewsService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<NewsItem>> GetAllNewsAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var news = await connection.QueryAsync<NewsItem>("SELECT n.Id, n.Title, n.Content, n.PublishedDate, c.Name AS CategoryName FROM News n JOIN Categories c ON n.CategoryId = c.Id");
                return news.ToList();
            }
        }

        public async Task<List<NewsItem>> GetNewsByCategoryAsync(int categoryId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var news = await connection.QueryAsync<NewsItem>(
                    "SELECT n.Id, n.Title, n.Content, n.PublishedDate, c.Name AS CategoryName FROM News n JOIN Categories c ON n.CategoryId = c.Id WHERE c.Id = @categoryId",
                    new { categoryId = categoryId });
                return news.ToList();
            }
        }
        public async Task<List<Category>> GetCategoriesAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var categories = await connection.QueryAsync<Category>("SELECT Id, Name FROM Categories");
                return categories.ToList();
            }
        }

        public async Task AddNewsAsync(NewsItem newsItem)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "INSERT INTO News (Title, Content, PublishedDate, CategoryId) VALUES (@Title, @Content, @PublishedDate, @CategoryId)";
                await connection.ExecuteAsync(sql, newsItem);
            }
        }

        public async Task<NewsItem> GetNewsByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var newsItem = await connection.QuerySingleAsync<NewsItem>("SELECT * FROM News WHERE Id = @Id", new { Id = id });
                return newsItem;
            }
        }

        public async Task<NewsItem> GetNewsByIdAsync2(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var newsItem = await connection.QuerySingleAsync<NewsItem>("SELECT n.Id, n.Title, n.Content, n.PublishedDate, c.Name AS CategoryName FROM News n JOIN Categories c ON n.CategoryId = c.Id WHERE n.Id = @Id", new { Id = id });
                return newsItem;
            }
        }

        public async Task UpdateNewsAsync(NewsItem newsItem)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "UPDATE News SET Title = @Title, Content = @Content, PublishedDate = @PublishedDate, CategoryId = @CategoryId WHERE Id = @Id";
                await connection.ExecuteAsync(sql, newsItem);
            }
        }

        public async Task DeleteNewsAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "DELETE FROM News WHERE Id = @Id";
                await connection.ExecuteAsync(sql, new { Id = id });
            }
        }
    }
}