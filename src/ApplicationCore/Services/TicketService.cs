using System;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Microsoft.eShopWeb.ApplicationCore.Entities.TicketAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Specifications;

namespace Microsoft.eShopWeb.ApplicationCore.Services;

public class TicketService : ITicketService
{
    private readonly IRepository<TicketItem> _ticketRepository;
    private readonly IAppLogger<BasketService> _logger;
    
    public TicketService(IRepository<TicketItem> ticketRepository, IAppLogger<BasketService> logger)
    {
        _ticketRepository = ticketRepository;
        _logger = logger;
    }
    public async Task CreateTicketAsync(string userId, int eventId)
    {
        Console.WriteLine("CreateTicketAsync called.");
        var ticket = new TicketItem(userId, eventId);
        
        await _ticketRepository.AddAsync(ticket);
       
    }

    public async Task UpdateTicketEventAsync(int ticketId, string userId, int eventId)
    {
       TicketItem ticket = await _ticketRepository.GetByIdAsync(ticketId);
       
       if(ticket == null)
       {
           throw new NotFoundException("Ticket not found", ticketId.ToString());
       }
       
       ticket.UpdateEventId(eventId);
       ticket.UpdateUserId(userId);
       
       await _ticketRepository.UpdateAsync(ticket);
    }

    public async  Task DeleteTicketAsync(int ticketId)
    {
        TicketItem ticket = await _ticketRepository.GetByIdAsync(ticketId);
        
        if (ticket != null)
        {
            await _ticketRepository.DeleteAsync(ticket);
        }
        
    }

    public async Task<bool> CheckTicketExistsAsync(string userId, int eventId)
    {
        var spec = new TicketItemSpecification(userId, eventId);
        TicketItem ticket = await _ticketRepository.FirstOrDefaultAsync(spec);
        
        return ticket != null;
    }
}
