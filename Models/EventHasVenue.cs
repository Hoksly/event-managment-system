using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crm_minimal.Models
{
    public class EventHasVenue
    {
        [Key]
        public int IdEventHasVenue { get; set; }

        [ForeignKey("Event")]
        public int IdEvent { get; set; }

        public Event Event { get; set; }

        [ForeignKey("Venue")]
        public int IdVenue { get; set; }

        public Venue Venue { get; set; }
    }
}
