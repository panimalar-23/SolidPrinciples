
using SolidInventoryApp.Interfaces;
using SolidInventoryApp.Models;

namespace SolidInventoryApp.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> products = new();

        public void Add(Product product)
        {
            products.Add(product);
        }

        public List<Product> GetAll()
        {
            return products;
        }
    }
}

