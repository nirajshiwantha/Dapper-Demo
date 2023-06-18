using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace DapperExample
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=.; Database=DapperExample; Trusted_Connection=true; TrustServerCertificate=true;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Retrieve all products from the database using Dapper
                List<Product> products = connection.Query<Product>("SELECT * FROM Products").AsList();

                // Display the retrieved products
                Console.WriteLine("Products:");
                foreach (Product product in products)
                {
                    Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Description: {product.Description}");
                }
            }

            Console.ReadLine();
        }
    }
}
