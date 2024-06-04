using Microsoft.eShopWeb.ApplicationCore.Entities.TicketAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Specifications;
using Microsoft.eShopWeb.Web.ViewModels;

namespace Microsoft.eShopWeb.Web.Features.MyTickets;

public class GetMyTicketsHandler
{
    private readonly IReadRepository<TicketItem> _ticketRepository;

    public GetMyTicketsHandler(IReadRepository<TicketItem> ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<IEnumerable<TicketViewModel>> Handle(GetMyTickets request,
        CancellationToken cancellationToken)
    {
        var specification = new TicketItemSpecification(request.UserId);
        var orders = await _ticketRepository.ListAsync(specification, cancellationToken);

        return orders.Select(o => new TicketViewModel()
        {
            TicketId = o.Id,
            Event = new EventViewModel()
            {
                Id = o.Event.Id,
                Name = o.Event.Name,
                StartDate = o.Event.StartDate,
                Price = o.Event.Price,
                PictureUri = o.Event.PictureUri
            }
            
        });
    }
}
