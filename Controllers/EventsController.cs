using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using crm_minimal.Data;
using crm_minimal.Data.Dao;
using crm_minimal.Models;

namespace crm_minimal.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventDao _eventDao;
        public EventsController(IEventDao eventDao)
        {
            _eventDao = eventDao;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            try
            {
                var events = await _eventDao.GetAllEvents(); 
                return Ok(events);  
            } 
            catch (Exception ex)
            {
                // Log the error
                return StatusCode(500, "Internal server error."); 
            }
        }
        
        
        // GET: api/Events/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEventById(int id)
        {
            try
            {
                var eventItem = await _eventDao.GetEventById(id);

                if (eventItem == null)
                {
                    return NotFound(); // Use the built-in NotFound helper
                }

                return Ok(eventItem);  // Use Ok for successful responses with data
            }
        
            catch (Exception ex)
            {
                // Log the unexpected exception for debugging
                return StatusCode(500, "An error occurred while processing your request: " + ex.Message);
            }
        }


        // GET: api/Events/name?eventName=SomeEventName
        [HttpGet("name")]
        public async Task<ActionResult<IEnumerable<Event>>> GetEventsByName(string eventName)
        {
            if (string.IsNullOrWhiteSpace(eventName))
            {
                return BadRequest("Search term cannot be empty.");
            }

            try 
            {
                return Ok(await _eventDao.GetEventsByName(eventName));
            }
            catch (Exception ex)
            {
                // Log the error
                return StatusCode(500, "An error occurred while processing your request: " + ex.Message);
            }
        }


        // GET: api/Events/description?desc=SomeDescription
        [HttpGet("description")]
        public async Task<ActionResult<IEnumerable<Event>>> GetEventsByDescription(string desc)
        {
            if (string.IsNullOrWhiteSpace(desc))
            {
                return BadRequest("Search term cannot be empty.");
            }

            try 
            {
                return Ok(await _eventDao.GetEventsByDescription(desc));
            }
            catch (Exception ex)
            {
                // Log the error
                return StatusCode(500, "An error occurred while processing your request: " + ex.Message);
            }
        }

        // GET: api/Events/search?q=SomeSearchTerm
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Event>>> SearchEvents(string q)
        {
            if (string.IsNullOrWhiteSpace(q))
            {
                return BadRequest("Search term cannot be empty.");
            }

            try 
            {
                return Ok(await _eventDao.SearchEvents(q));
            }
            catch (Exception ex)
            {
                // Log the error
                return StatusCode(500, "An error occurred while processing your request: " + ex.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event eventData)
        {
            try
            {
                var newEvent = await _eventDao.CreateEvent(eventData);
                return CreatedAtAction(nameof(GetEventById), new { id = newEvent.Id }, newEvent);
            }
            catch (Exception ex)
            {
                // Log the error
                return StatusCode(500, "An error occurred while processing your request: " + ex.Message);
            } 
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Event>> DeleteEvent(int id)
        {
            try
            {
                var deleted = await _eventDao.DeleteEvent(id);
                if (!deleted)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the error
                return StatusCode(500, "An error occurred while processing your request: " + ex.Message);
            }    
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event eventData)
        {
            if (id != eventData.Id)
            {
                return BadRequest();
            }

            try
            {
                var updated = await _eventDao.UpdateEvent(eventData);
                if (!updated)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the error
                return StatusCode(500, "An error occurred while processing your request: " + ex.Message);
            }
        }

    }
}
