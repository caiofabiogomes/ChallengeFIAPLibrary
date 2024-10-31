using ChallengeFIAPLibrary.Domain.Entities;
using ChallengeFIAPLibrary.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace ChallengeFIAPLibrary.Infrastructure.Persistence.Repositories
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : BaseEntity
    { 
        private readonly WriteDbContext _context;
        private readonly ReadDbContext _contextRead;

        public AbstractRepository(WriteDbContext context, ReadDbContext contextRead)
        {
            _context = context;
            _contextRead = contextRead;
        }


        public async Task AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        { 
            return await _contextRead.Set<T>().Find(c => c.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _contextRead.Set<T>().Find(_ => true).ToListAsync();
        }
    }
}
