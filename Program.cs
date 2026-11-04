
using SolidInventoryApp.Interfaces;
using SolidInventoryApp.Models;
using SolidInventoryApp.Repositories;
using SolidInventoryApp.Services;

IProductRepository repository = new ProductRepository();
IProductService service = new ProductService(repository);

bool running = true;

while (running)
{
    Console.WriteLine("\n===== PRODUCT INVENTORY SYSTEM =====");
    Console.WriteLine("1. Add Product");
    Console.WriteLine("2. List Products");
    Console.WriteLine("3. Exit");
    Console.Write("Enter your choice: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Enter product ID: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter product name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Enter product price: ");
            decimal price = decimal.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter product quantity: ");
            int quantity = int.Parse(Console.ReadLine() ?? "0");

            try
            {
                service.AddProduct(new Product
                {
                    Id = id,
                    Name = name,
                    Price = price,
                    Quantity = quantity
                });

                Console.WriteLine("Product added successfully!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            break;

        case "2":
            List<Product> products = service.GetProducts();

            if (products.Count == 0)
            {
                Console.WriteLine("No products available.");
            }
            else
            {
                Console.WriteLine("\nID\tName\t\tPrice\tQuantity");

                foreach (Product product in products)
                {
                    Console.WriteLine(
                        $"{product.Id}\t{product.Name}\t\t{product.Price:C}\t{product.Quantity}");
                }
            }
            break;

        case "3":
            running = false;
            Console.WriteLine("Exiting Inventory System...");
            break;

        default:
            Console.WriteLine("Invalid choice. Try again.");
            break;
    }
}
