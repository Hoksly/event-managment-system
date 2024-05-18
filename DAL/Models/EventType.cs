namespace crm_minimal.Models
{
    public class EventType
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        // Navigation Property (many-to-many)
        public ICollection<EventHasType> EventHasTypes { get; set; }
    }
}
