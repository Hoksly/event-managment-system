namespace BLL.Models
{
    public class EventHasTypeBusinessModel
    {
        public int EventId { get; set; }
        public int TypeId { get; set; }
        // Navigation properties
        public EventBusinessModel Event { get; set; }
        public EventTypeBusinessModel EventType { get; set; }
    }

}
