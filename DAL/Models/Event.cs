using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace crm_minimal.Models
{
public class Event
    {
        [Key] // Denotes Primary Key
        public int Id { get; set; }

        [Required] // Ensures Title is not null or empty
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; } 

        [Required]
        public DateTime EndDate { get; set; } 

        public DateTime CreatedAt { get; set; } 

        public DateTime UpdatedAt { get; set; }  

        public bool IsListed { get; set; }

        public string ImageBanner { get; set; } = null!; 

        // Assuming SeatsMap is a JSON representation, for now
        public string SeatsMap { get; set; } = null!;

        public ICollection<EventHasType> EventHasTypes { get; set; } = null!;
        public ICollection<EventHasVenue> EventHasVenues { get; set; } = null!;
    }
}
