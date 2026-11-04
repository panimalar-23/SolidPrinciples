
using SolidInventoryApp.Models;

namespace SolidInventoryApp.Interfaces
{
    public interface IProductService
    {
        void AddProduct(Product product);
        List<Product> GetProducts();
    }
}

