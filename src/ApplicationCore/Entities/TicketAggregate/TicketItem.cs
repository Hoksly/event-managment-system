using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.Infrastructure.Data.Queries;

namespace Microsoft.eShopWeb.ApplicationCore.Entities.TicketAggregate;

public class TicketItem : BaseEntity, IAggregateRoot
{
    public TicketItem(string userId, int eventId)
    {
        UserId = userId;
        EventId = eventId;
    }

    #pragma warning disable CS8618 // Required by Entity Framework
    public string UserId { get; private set; } 
    public int EventId { get; private set; }
    public Event Event { get; private set; }
    
    public void UpdateEventId(int eventId)
    {
        EventId = eventId;
    }
    
    public void UpdateUserId(string userId)
    {
        UserId = userId;
    }
   
    public void UpdateEvent(Event @event)
    {
        Event = @event;
    }
}
