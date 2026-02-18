using Microsoft.EntityFrameworkCore;

namespace EventPlanner.Data
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {
        }

        public DbSet<EventPlanner.EventItem> Events { get; set; } = null!;
    }
}
