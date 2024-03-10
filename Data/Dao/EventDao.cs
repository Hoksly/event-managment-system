using crm_minimal.Models;
using Microsoft.EntityFrameworkCore;

namespace crm_minimal.Data.Dao
{
    public class EventDao : IEventDao
    {
        private readonly ApplicationManagementContext _context;

        public EventDao(ApplicationManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Event> GetEventById(int id)
        {
            var eventItem = await _context.Events.FindAsync(id);
            if (eventItem == null)
            {
                // Consider throwing a custom exception for better handling
                return null; 
            }
            return eventItem;
        }

        public async Task<IEnumerable<Event>> GetEventsByName(string eventName)
        {
            return await _context.Events
                .Where(e => e.Title.Contains(eventName)) 
                .ToListAsync(); 
        }

        public async Task<IEnumerable<Event>> GetEventsByDescription(string desc)
        {
            return await _context.Events
                .Where(e => e.Description.Contains(desc)) 
                .ToListAsync(); 
        }

        public async Task<IEnumerable<Event>> SearchEvents(string q)
        {
            // More flexible search across title, description, etc.
            return await _context.Events
                .Where(e => e.Title.Contains(q) || e.Description.Contains(q))
                .ToListAsync(); 
        }

        public async Task<Event> CreateEvent(Event eventData)
        {
            _context.Events.Add(eventData);
            await _context.SaveChangesAsync();
            return eventData; 
        }

        public async Task<bool> DeleteEvent(int id)
        {
            var eventItem = await _context.Events.FindAsync(id);
            if (eventItem == null)
            {
                return false; 
            }

            _context.Events.Remove(eventItem);
            await _context.SaveChangesAsync();
            return true; 
        }

        public async Task<bool> UpdateEvent(Event eventData)
        {
            _context.Entry(eventData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true; 
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(eventData.Id))
                {
                    return false; 
                }
                else
                {
                    throw; 
                }
            }
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}
