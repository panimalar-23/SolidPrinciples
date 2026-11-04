
using SolidInventoryApp.Models;

namespace SolidInventoryApp.Interfaces
{
    public interface IProductRepository
    {
        void Add(Product product);
        List<Product> GetAll();
    }
}
