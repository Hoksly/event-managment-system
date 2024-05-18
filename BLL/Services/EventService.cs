using BLL.Models;
using crm_minimal.DAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using crm_minimal.Models;
using Mapper = BLL.Utils.Mapper;

namespace BLL.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventService(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventBusinessModel>> GetAllEventsAsync()
        {
            var events = await _eventRepository.GetAllEventsAsync();
            return _mapper.Map<IEnumerable<EventBusinessModel>>(events);
        }

        public async Task<EventBusinessModel> GetEventByIdAsync(int eventId)
        {
            var evt = await _eventRepository.GetEventByIdAsync(eventId);
            return _mapper.Map<EventBusinessModel>(evt);
        }

        public async Task CreateEventAsync(EventBusinessModel evt)
        {
            await _eventRepository.AddEventAsync(_mapper.Map<Event>(evt));
            
        }

        public async Task UpdateEventAsync(EventBusinessModel evt)
        {
            await _eventRepository.UpdateEventAsync(_mapper.Map<Event>(evt));
        }

        public async Task DeleteEventAsync(int eventId)
        {
            await _eventRepository.DeleteEventAsync(eventId);
        }
    }
}
