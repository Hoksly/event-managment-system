using crm_minimal.Models;

namespace crm_minimal.DAL.Repositories
{
    public interface IEventRepository
    {
       Task<IEnumerable<Event>> GetAllEventsAsync();
       Task<Event> GetEventByIdAsync(int eventId);
       Task AddEventAsync(Event evt);
       Task UpdateEventAsync(Event evt);
       Task DeleteEventAsync(int eventId);
    }
}
