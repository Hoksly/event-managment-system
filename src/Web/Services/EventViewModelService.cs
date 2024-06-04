using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Specifications;
using Microsoft.eShopWeb.Infrastructure.Data.Queries;
using Microsoft.eShopWeb.Web.Interfaces;

namespace Microsoft.eShopWeb.Web.Services;

using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.Web.ViewModels;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

public class EventViewModelService : IEventViewModelService
{
    private readonly ILogger<EventViewModelService> _logger;
    private readonly IRepository<Event> _eventRepository;
    private readonly IRepository<EventType> _eventTypeRepository;
    private readonly IRepository<EventLocation> _locationRepository;

    public EventViewModelService(
        ILogger<EventViewModelService> logger,
        IRepository<Event> eventRepository,
        IRepository<EventType> eventTypeRepository,
        IRepository<EventLocation> locationRepository)
    {
        _logger = logger;
        _eventRepository = eventRepository;
        _eventTypeRepository = eventTypeRepository;
        _locationRepository = locationRepository;
    }
    
    public async Task<EventViewModel> GetEventByIdAsync(int id)
    {
        var eventEntity = await _eventRepository.GetByIdAsync(id);
        if (eventEntity == null)
        {
            _logger.LogError("Event with id {id} not found.", id);
            return null;
        }
        return new EventViewModel
        {
            Name = eventEntity.Name,
            Description = eventEntity.Description,
            Price = eventEntity.Price,
            PictureUri = eventEntity.PictureUri,
            StartDate = eventEntity.StartDate,
            EndDate = eventEntity.EndDate ,
            LinkToEvent = eventEntity.LinkToEvent,
            Id = eventEntity.Id,
        };
    }

    public async Task<List<EventViewModel>> GetUserEvents(string userId)
    {
        var events = await _eventRepository.ListAsync(new EventSpecification(userId));
        return events.Select(e => new EventViewModel
        {
            Name = e.Name,
            Description = e.Description,
            Price = e.Price,
            PictureUri = e.PictureUri,
            StartDate = e.StartDate,
            EndDate = e.EndDate,
            LinkToEvent = e.LinkToEvent,
            Id = e.Id,
        }).ToList();
    }
}
