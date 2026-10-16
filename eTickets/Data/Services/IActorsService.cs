using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IActorsService
    {
        public Task<IEnumerable<Actor>> GetAllAsync();
        Task<Actor> GetByIdAsync(int id);
        public Task AddAsync(Actor actor);
        public Task<Actor> UpdateAsync(int id, Actor newActor);
        public  Task DeleteAsync(int id);
          
        
    }
}
