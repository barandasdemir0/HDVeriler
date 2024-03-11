using HD_Veriler.Models;
using HD_Veriler.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace HD_Veriler.Repositories.Concretes
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly HDVerilerContext _context;

        public Repository(HDVerilerContext context)
        {
            _context = context;
        }
        private DbSet<T> Table { get => _context.Set<T>(); }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }



        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

      
    }

}
