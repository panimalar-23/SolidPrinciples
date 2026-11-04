
using SolidInventoryApp.Interfaces;
using SolidInventoryApp.Models;

namespace SolidInventoryApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;

        public ProductService(IProductRepository repository)
        {
            this.repository = repository;
        }

        public void AddProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ArgumentException("Product name is required.");

            if (product.Price <= 0)
                throw new ArgumentException("Price must be greater than zero.");

            if (product.Quantity < 0)
                throw new ArgumentException("Quantity cannot be negative.");

            repository.Add(product);
        }

        public List<Product> GetProducts()
        {
            return repository.GetAll();
        }
    }
}
