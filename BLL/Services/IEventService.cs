using BLL.Models;
using System.Collections.Generic;

namespace BLL.Services
{
    public interface IEventService
    {
        Task<IEnumerable<EventBusinessModel>> GetAllEventsAsync();
        Task<EventBusinessModel> GetEventByIdAsync(int eventId);
        Task CreateEventAsync(EventBusinessModel eventModel);
        Task UpdateEventAsync(EventBusinessModel eventModel);
        Task DeleteEventAsync(int eventId);
    }
}
