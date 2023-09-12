using Dapper;
using DataAcess.Model;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace DataAcess;

public class Program
{
    static void Main(string[] args)
    {
        const string connectionString 
            = "Server=localhost,1433;Database=balta; User ID=sa;Password=1q2w3e4r@#$";
        var category = new Category();
        category.Id = Guid.NewGuid();
        category.Title = "Expert AWS";
        category.Url = "Amazon";
        category.Order = 8;
        category.Description = "Aprenda AWS";
        category.Summary = "AWS Cloud";
        category.Featured = false;

        var insertSql = @"INSERT INTO
                        [Category]
                            VALUES
                        (@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";
        using (var connection = new SqlConnection(connectionString))
        {
            var rows = connection.Execute(insertSql, new
            {
                category.Id,
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured,
            });
            Console.WriteLine(rows);
            var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
            foreach (var item in categories)
            {
                Console.WriteLine(item.Title);
            }
        }
        Console.WriteLine("Hello");
    }
}
