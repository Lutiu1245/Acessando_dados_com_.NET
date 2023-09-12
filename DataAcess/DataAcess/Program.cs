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
            ReadCategories(connection);
            //CreateCategorieList(connection);
            UpdateCategorie(connection);
        }
        //Console.WriteLine("Hello");
    }
    static void ReadCategories(SqlConnection connection)
    {
        var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
        foreach (var item in categories)
        {
            Console.WriteLine(item.Title);
        }
    }
    static void CreateCategorie(SqlConnection connection)
    {
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
    }
    static void UpdateCategorie(SqlConnection connection)
    {
        var UpdateQuery = @"UPDATE [Category] SET [Title]= @title WHERE [Id]=@id";
        var row = connection.Execute(UpdateQuery, new
        {
            id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
            title = "FrontEnd Master"
        }) ;
        Console.WriteLine("update"+ row);
    }
}
