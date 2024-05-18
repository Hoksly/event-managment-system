namespace BLL.Models
{
    public class EventTypeBusinessModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        // Navigation property
        public ICollection<EventHasTypeBusinessModel> EventHasTypes { get; set; }
    }

}
