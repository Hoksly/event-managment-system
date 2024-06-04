using MediatR;
using Microsoft.eShopWeb.Web.ViewModels;

namespace Microsoft.eShopWeb.Web.Features.MyTickets;

public class GetMyTickets : IRequest<IEnumerable<TicketViewModel>>
{
    public string UserId { get; set; }

    public GetMyTickets(string userId)
    {
        UserId = userId;
    }
}
