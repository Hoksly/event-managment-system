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
        private readonly EventContext _context;

        public EventTypesController(EventContext context)
        {
            _context = context;
        }

        // GET: api/EventTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventType>>> GetEventTypes()
        {
            return await _context.EventTypes.ToListAsync();
        }

        // GET: api/EventTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventType>> GetEventType(int id)
        {
            var eventType = await _context.EventTypes.FindAsync(id);

            if (eventType == null)
            {
                return NotFound();
            }

            return eventType;
        }

        // PUT: api/EventTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventType(int id, EventType eventType)
        {
            if (id != eventType.Id)
            {
                return BadRequest();
            }

            _context.Entry(eventType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EventTypes
        [HttpPost]
        public async Task<ActionResult<EventType>> PostEventType(EventType eventType)
        {
            _context.EventTypes.Add(eventType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventType", new { id = eventType.Id }, eventType);
        }

        // DELETE: api/EventTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventType(int id)
        {
            var eventType = await _context.EventTypes.FindAsync(id);
            if (eventType == null)
            {
                return NotFound();
            }

            _context.EventTypes.Remove(eventType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventTypeExists(int id)
        {
            return _context.EventTypes.Any(e => e.Id == id);
        }
    }
}
