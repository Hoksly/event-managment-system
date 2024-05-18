using crm_minimal.Data;
using crm_minimal.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace crm_minimal.DAL.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EventContext _context;

        public EventRepository(EventContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Event> GetEventByIdAsync(int eventId)
        {
            return await _context.Events.FindAsync(eventId);
        }

        public async Task AddEventAsync(Event evt)
        {
            _context.Events.Add(evt);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEventAsync(Event evt)
        {
            _context.Events.Update(evt);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEventAsync(int eventId)
        {
            var evt = await _context.Events.FindAsync(eventId);
            if (evt != null)
            {
                _context.Events.Remove(evt);
                await _context.SaveChangesAsync();
            }
        }
    }
}
