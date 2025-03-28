namespace ShopEase.Models
{
    public class Product
    {
        public int ProductID { get; set; }     // Unique identifier for the product
        public string Name { get; set; } = string.Empty; // Product name
        public decimal Price { get; set; }    // Product price
        public string Category { get; set; } = string.Empty; // Product category

        // Method to display product details
        public void PrintDetails()
        {
            Console.WriteLine($"Product: {Name} | Price: ${Price:F2} | Category: {Category}");
        }
    }
}
