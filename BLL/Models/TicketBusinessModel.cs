namespace BLL.Models
{
    public class TicketBusinessModel
    {
        public int IdTicket { get; set; }
        public int IdEvent { get; set; }
        public EventBusinessModel Event { get; set; }
        public int IdCustomer { get; set; }
        public CustomerBusinessModel Customer { get; set; }
        public string SeatInfo { get; set; }
    }

}
