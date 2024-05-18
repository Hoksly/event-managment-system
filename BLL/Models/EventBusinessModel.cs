namespace BLL.Models
{
    public class EventBusinessModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsListed { get; set; }
        public string ImageBanner { get; set; }
        public string SeatsMap { get; set; }
        // Collections for related types and venues
        public ICollection<EventHasTypeBusinessModel> EventHasTypes { get; set; }
        public ICollection<EventHasVenueBusinessModel> EventHasVenues { get; set; }
    }

}
