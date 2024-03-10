using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace crm_minimal.Models
{
    [Keyless] // Mark as keyless entity type
    public class EventHasType
    {
        // Foreign key properties
        public int EventId { get; set; }
        public int TypeId { get; set; }

        // Navigation properties
        public Event Event { get; set; }
        public EventType EventType { get; set; }
    }
}
