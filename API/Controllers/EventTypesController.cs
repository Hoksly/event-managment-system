using AutoMapper;
using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using crm_minimal.Data;
using crm_minimal.Models;


namespace crm_minimal.Controllers
{
   [Route("api/[controller]")]
    [ApiController]
    public class EventTypesController : ControllerBase
    {
        private readonly IEventTypeService _eventService;
        private readonly IMapper _mapper;

        public EventTypesController(IEventTypeService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        // GET: api/EventTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventTypeBusinessModel>>> GetEventTypes()
        {
            IEnumerable<EventTypeBusinessModel> eventTypes = await _eventService.GetAllEventTypesAsync();
      
            return Ok(eventTypes);
        }

        // GET: api/EventTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventTypeBusinessModel>> GetEvent(int id)
        {
            var eventItem = await _eventService.GetEventTypeAsync(id);

            return eventItem;
        }

        // PUT: api/EventTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventType(int id, EventTypeBusinessModel eventType)
        {
            if (id != eventType.Id)
            {
                return BadRequest();
            }

            await _eventService.UpdateEventTypeAsync(eventType);

            return NoContent();
        }

        // POST: api/EventTypes
        [HttpPost]
        public async Task<ActionResult<EventType>> PostEventType(EventTypeBusinessModel eventType)
        {
            await _eventService.CreateEventTypeAsync(eventType);
            
            return CreatedAtAction("GetEventType", new { id = eventType.Id }, eventType);
        }

        // DELETE: api/EventTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventType(int id)
        {
            var eventType = await _eventService.GetEventTypeAsync(id);
            
            if (eventType.Equals(null))
            {
                return NotFound();
            }

            await _eventService.DeleteEventTypeAsync(id);
            
            return NoContent();
        }

    }
}
