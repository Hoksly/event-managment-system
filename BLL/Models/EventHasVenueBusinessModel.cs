namespace BLL.Models
{
    public class EventHasVenueBusinessModel
    {
        public int IdEventHasVenue { get; set; }
        public int IdEvent { get; set; }
        public EventBusinessModel Event { get; set; }
        public int IdVenue { get; set; }
        public VenueBusinessModel Venue { get; set; }
    }

}
