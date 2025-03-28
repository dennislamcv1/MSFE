using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;

namespace ShopEase.Models
{
    public class Cart
    {
        private List<Product> _products = new List<Product>();

        private string connectionString = "Server=localhost;Database=Shop;User ID=root;Password=yourpassword;";

        // Add a product to the cart and save it to the database
        public void AddProduct(Product product)
        {
            _products.Add(product);
            SaveToDatabase(product);
        }

        // Remove a product from the cart and delete it from the database
        public void RemoveProduct(int productId)
        {
            Product? productToRemove = _products.FirstOrDefault(p => p.ProductID == productId);
            if (productToRemove != null)
            {
                _products.Remove(productToRemove);
                RemoveFromDatabase(productId);
            }
        }

        // Display all cart items
        public void DisplayCartItems()
        {
            Console.WriteLine("Cart Items:");
            foreach (var product in _products)
            {
                product.PrintDetails();
            }
        }

        // Calculate the total price of all items in the cart
        public decimal CalculateTotal()
        {
            return _products.Sum(p => p.Price);
        }

        // Save product to MySQL database
        private void SaveToDatabase(Product product)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Products (ProductID, Name, Price, Category) VALUES (@ProductID, @Name, @Price, @Category)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductID", product.ProductID);
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@Category", product.Category);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Remove product from MySQL database
        private void RemoveFromDatabase(int productId)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Products WHERE ProductID = @ProductID";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductID", productId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
