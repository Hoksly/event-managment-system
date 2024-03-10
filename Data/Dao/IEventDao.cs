using crm_minimal.Models;

namespace crm_minimal.Data.Dao
{
    public interface IEventDao
    {
        Task<IEnumerable<Event>> GetAllEvents(); 
        Task<Event> GetEventById(int id); 
        Task<IEnumerable<Event>> GetEventsByName(string eventName);
        Task<IEnumerable<Event>> GetEventsByDescription(string desc);
        Task<IEnumerable<Event>> SearchEvents(string q);
        Task<Event> CreateEvent(Event eventData); 
        Task<bool> DeleteEvent(int id); 
        Task<bool> UpdateEvent(Event eventData);
    }

    
}
