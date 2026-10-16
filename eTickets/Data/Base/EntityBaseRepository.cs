
namespace eTickets.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
    
        public Task <IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        public Task AddAsync(T actor);
        public Task<T> UpdateAsync(int id, T newActor)
        {

        }
        public Task DeleteAsync(int id)
        {

        }

        Task<T> IEntityBaseRepository<T>.GetByIdAsync(int id)
        {
            return GetByIdAsync(id);
        }
    }

      
}
