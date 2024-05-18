using Microsoft.AspNetCore.Mvc;
using BLL.Services;
using BLL.Models;
using System.Threading.Tasks;
using crm_minimal.DAL.Repositories;

namespace crm_minimal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        
        EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }
        
        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventBusinessModel>>> GetEvents()
        {
            return Ok(await _eventService.GetAllEventsAsync());
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventBusinessModel>> GetEvent(int id)
        {
            var eventItem = await _eventService.GetEventByIdAsync(id);

            if (eventItem == null)
            {
                return NotFound();
            }

            return eventItem;
        }

        // POST: api/Events
        [HttpPost]
        public async Task<ActionResult<EventBusinessModel>> PostEvent(EventBusinessModel eventItem)
        {
            await _eventService.CreateEventAsync(eventItem);

            return CreatedAtAction(nameof(GetEvent), new { id = eventItem.Id }, eventItem);
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, EventBusinessModel eventItem)
        {
            if (id != eventItem.Id)
            {
                return BadRequest();
            }

            await _eventService.UpdateEventAsync(eventItem);
            
            return NoContent();
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            await _eventService.DeleteEventAsync(id);
            
            return NoContent();
        }
    }
}