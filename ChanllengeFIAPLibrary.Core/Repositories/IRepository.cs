using ChallengeFIAPLibrary.Domain.Entities;

namespace ChallengeFIAPLibrary.Domain.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T?> GetByIdAsync(Guid id);
        Task<List<T>> GetAllAsync();
    }
}
