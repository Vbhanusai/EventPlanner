using Microsoft.EntityFrameworkCore;
using EventPlanner.Data;

namespace EventPlanner.Repositories
{
    public class EfEventRepository : IEventRepository
    {
        private readonly EventContext _context;

        public EfEventRepository(EventContext context)
        {
            _context = context;
        }

        public async Task<EventPlanner.EventItem> CreateAsync(EventPlanner.EventItem item)
        {
            _context.Events.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _context.Events.FindAsync(id);
            if (item == null) return false;
            _context.Events.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<EventPlanner.EventItem>> GetAllAsync()
        {
            return await _context.Events.AsNoTracking().ToListAsync();
        }

        public async Task<EventPlanner.EventItem?> GetByIdAsync(int id)
        {
            return await _context.Events.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(EventPlanner.EventItem item)
        {
            if (!await _context.Events.AnyAsync(e => e.Id == item.Id)) return false;
            _context.Events.Update(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
