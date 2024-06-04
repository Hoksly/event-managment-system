using Ardalis.Specification;
using Microsoft.eShopWeb.ApplicationCore.Entities.TicketAggregate;

namespace Microsoft.eShopWeb.ApplicationCore.Specifications;

public class TicketItemSpecification : Specification<TicketItem>
{
    public TicketItemSpecification(string userId)
    {
        Query.Where(i => i.UserId == userId);
    }
    
    public TicketItemSpecification(string userId, int eventId)
    {
        Query.Where(i => i.UserId == userId && i.EventId == eventId);
    }

}
