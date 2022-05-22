using ETicaretWebApp.Models;

namespace ETicaretWebApp.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();

        Task<Product?> GetByIdAsync(int id);

        Task<int> GetCountAsync();

        Task<IEnumerable<Product>> GetSliceAsync(int offset, int size);

        bool Add(Product product);

        bool Update(Product product);

        bool Delete(Product product);

        bool Save();
    }
}
