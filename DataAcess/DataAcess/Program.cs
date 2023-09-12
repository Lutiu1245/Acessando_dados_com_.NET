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
        using (var connection = new SqlConnection(connectionString))
        {
            var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
            foreach (var category in categories)
            {
                Console.WriteLine(category.Title);
            }
        }
        Console.WriteLine("Hello");
    }
}
