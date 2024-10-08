using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeFIAPLibrary.Domain.Entities;
using ChallengeFIAPLibrary.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChallengeFIAPLibrary.Infrastructure.Persistence.Repositories
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : BaseEntity
    { 
        private readonly WriteDbContext _context;

        public AbstractRepository(WriteDbContext context)
        {
            _context = context;
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
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
