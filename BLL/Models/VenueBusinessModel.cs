using BLL.Models;

namespace BLL.Models
{
    public class VenueBusinessModel
    {
        public int IdVenue { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ContactInfo { get; set; }
        public string ImageBanner { get; set; }
        public int Capacity { get; set; }
        public string MapLink { get; set; }
        public ICollection<EventHasVenueBusinessModel> EventHasVenues { get; set; }
    }

}
