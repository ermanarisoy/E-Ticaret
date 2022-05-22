using ETicaretWebApp.Data;
using ETicaretWebApp.Interfaces;
using ETicaretWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ETicaretWebApp.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Product product)
        {
            _context.Add(product);
            return Save();
        }

        public bool Delete(Product product)
        {
            _context.Remove(product);
            return Save();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetSliceAsync(int offset, int size)
        {
            return await _context.Products.Include(i => i.Category).Skip(offset).Take(size).ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.Include(i => i.Category).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Products.CountAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool Update(Product product)
        {
            _context.Update(product);
            return Save();
        }
    }
}
