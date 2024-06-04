using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Interfaces;

public interface ITicketService
{
    Task CreateTicketAsync(string userId, int eventId);
    Task UpdateTicketEventAsync(int ticketId, string userId, int eventId);
    Task DeleteTicketAsync(int ticketId);
    
    // Add additional methods for ticket management
    Task<bool> CheckTicketExistsAsync(string userId, int eventId);
    
}
