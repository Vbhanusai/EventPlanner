using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventPlanner.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<EventPlanner.EventItem>> GetAllAsync();
        Task<EventPlanner.EventItem?> GetByIdAsync(int id);
        Task<EventPlanner.EventItem> CreateAsync(EventPlanner.EventItem item);
        Task<bool> UpdateAsync(EventPlanner.EventItem item);
        Task<bool> DeleteAsync(int id);
    }
}
