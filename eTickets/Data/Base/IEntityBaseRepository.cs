using eTickets.Models;

namespace eTickets.Data.Base
{
    public interface IEntityBaseRepository<T> where T:class, IEntityBase,new()
    {
        public Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        public Task AddAsync(T entity);
        public Task UpdateAsync(int id, T newEntity);
        public Task DeleteAsync(int id);

    }
}
