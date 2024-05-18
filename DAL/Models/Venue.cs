using System.ComponentModel.DataAnnotations;

namespace crm_minimal.Models
{
    public class Venue
    {
        [Key]
        public int IdVenue { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string ContactInfo { get; set; }

        public string ImageBanner { get; set; }

        public int Capacity { get; set; }

        public string MapLink { get; set; }

        public ICollection<EventHasVenue> EventHasVenues { get; set; } = null!;
    }
}
