using BLL.Models;
using crm_minimal.Models;

namespace BLL.Services
{
    public interface IEventTypeService
    {
        Task<EventTypeBusinessModel> GetEventTypeAsync(int id);
        Task<IEnumerable<EventTypeBusinessModel>> GetAllEventTypesAsync();
        Task CreateEventTypeAsync(EventTypeBusinessModel eventType);
        Task UpdateEventTypeAsync(EventTypeBusinessModel eventType);
        Task DeleteEventTypeAsync(int id);
        
        Task<IEnumerable<EventBusinessModel>> GetEventsByTypeAsync(int eventTypeId);
        
    }
}
