using System.Security.Claims;
using Ardalis.GuardClauses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Specifications;
using Microsoft.eShopWeb.Web.Features.MyOrders;
using Microsoft.eShopWeb.Web.Features.OrderDetails;
using Microsoft.eShopWeb.Web.Interfaces;

namespace Microsoft.eShopWeb.Web.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
[Authorize] // Controllers that mainly require Authorization still use Controller/View; other pages use Pages
[Route("[controller]/[action]")]
public class RegistrationController : Controller
{
    private readonly ITicketService _ticketService;
    private readonly IEventViewModelService _eventViewModelService; // Replace with your event service interface

    public RegistrationController(ITicketService ticketService, IEventViewModelService eventViewModelService) // Dependency injection for event service
    {
        _ticketService = ticketService;
        _eventViewModelService = eventViewModelService;
       
    }

    [HttpGet]
    public async Task<IActionResult> MyRegistrations()
    {   
        Guard.Against.Null(User?.Identity?.Name, nameof(User.Identity.Name));
        var userId = User.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        var spec = new EventSpecification(userId);
        var viewModels = await _eventViewModelService.GetUserEvents(userId);
        var statusList = new List<bool>();
        for (int i = 0; i < viewModels.Count; i++) 
        {
            statusList.Add(viewModels[i].StartDate < DateTime.Now);
        }
        viewModels.Sort((x, y) => DateTime.Compare(y.EndDate, x.EndDate));
        ViewData["Status"] = statusList;
        return View(viewModels);
    }
}
