using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.Web.Interfaces;
using Microsoft.eShopWeb.Web.ViewModels;

namespace Microsoft.eShopWeb.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class EventsController : Controller
    {
        
        private readonly IEventViewModelService _eventService; // Replace with your event service interface
        private readonly ITicketService _ticketService;

        public EventsController(IEventViewModelService eventService, ITicketService ticketService) // Dependency injection for event service
        {
            _eventService = eventService;
            _ticketService = ticketService;
        }

        [HttpGet("{eventId:int}"), HttpPost("{eventId:int}")]
        public async Task<IActionResult> Index(int eventId)
        {
            var userId = User.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var eventView = await _eventService.GetEventByIdAsync(eventId);

            if (eventView == null)
            {
                return BadRequest("No such order found for this user.");
            }

            // Check if user is already registered (if user is logged in)
            bool isAlreadyRegistered = false;
            if (userId != null)
            {
                isAlreadyRegistered = await _ticketService.CheckTicketExistsAsync(userId, eventId);
            }

            // Pass both event details and registration status to view
            ViewData["isAlreadyRegistered"] = isAlreadyRegistered;
            return View("Event", eventView);
        }


        // Add additional action methods for specific event details, registration, etc.
        [HttpGet("{eventId:int}"), HttpPost("{eventId:int}")]
        [Authorize]
        public async Task<IActionResult> Register(int eventId)
        {
            Console.WriteLine(eventId);
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            Console.WriteLine(userId);
            // Check if user has already registered for this event (replace with actual logic)
            if (userId == null)
            {
                // Handle scenario where user ID is not found
                return BadRequest("Failed to retrieve user ID.");
            }
            try
            {
                Console.WriteLine("Creating ticket");
                if(!await _ticketService.CheckTicketExistsAsync(userId, eventId))
                    await _ticketService.CreateTicketAsync(userId, eventId);

                return RedirectToAction("Index", new { eventId }); // Redirect back to event details
            }
            catch (Exception ex)
            {
                // Handle registration failure and display error message in view
                ModelState.AddModelError(string.Empty, "Registration failed: " + ex.Message);
                return View("Event", await _eventService.GetEventByIdAsync(eventId)); // Pass event details back to view
            }
        }


         // User must be logged in to access this action
        public async Task<IActionResult> RegisterButton() // Separate action for the button
        {
            // This action doesn't need any specific logic, it just renders a view
            return View();
        }
    }
}
