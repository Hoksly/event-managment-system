using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using crm_minimal.Data;
using crm_minimal.Models;

namespace crm_minimal.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ApplicationManagementContext _context;

        public EventsController(ApplicationManagementContext context)
        {
            _context = context;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            return await _context.Events.ToListAsync();
        }
        
        
        // GET: api/Events/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEventById(int id)
        {
            var eventItem = await _context.Events.FindAsync(id);
            
            if (eventItem == null)
            {
                return NotFound("No such event exists.");
            }
            return eventItem;
        }

        // GET: api/Events/name?eventName=SomeEventName
        [HttpGet("name")]
        public async Task<ActionResult<IEnumerable<Event>>> GetEventsByName(string eventName)
        {
            return await _context.Events
                .Where(e => e.Title.Contains(eventName)) 
                .ToListAsync(); 
        }

        // GET: api/Events/description?desc=SomeDescription
        [HttpGet("description")]
        public async Task<ActionResult<IEnumerable<Event>>> GetEventsByDescription(string desc)
        {
            return await _context.Events
                .Where(e => e.Description.Contains(desc)) 
                .ToListAsync(); 
        }

        // GET: api/Events/search?q=SomeSearchTerm
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Event>>> SearchEvents(string q)
        {
            // More flexible search across title, description, etc.
            // Might involve LIKE or full-text search depending on your needs
            return await _context.Events
                .Where(e => e.Title.Contains(q) || e.Description.Contains(q))
                .ToListAsync(); 
        }
        
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event eventData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            _context.Events.Add(eventData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventById", new { id = eventData.Id }, eventData); 
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Event>> DeleteEvent(int id)
        {
            var eventItem = await _context.Events.FindAsync(id);
            if (eventItem == null)
            {
                return NotFound();
            }

            _context.Events.Remove(eventItem);
            await _context.SaveChangesAsync();

            return eventItem;
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event eventData)
        {
            if (id != eventData.Id)
            {
                return BadRequest("No such event exists.");
                
            }

            _context.Entry(eventData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
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

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}
