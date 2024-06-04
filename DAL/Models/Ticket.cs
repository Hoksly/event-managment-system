using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crm_minimal.Models
{
    public class Ticket
    {
        [Key]
        public int IdTicket { get; set; }

        [ForeignKey("Event")]
        public int IdEvent { get; set; }

        public Event Event { get; set; }

        [ForeignKey("Customer")]
        public int IdCustomer { get; set; }

        public RegisteredCustomer Customer { get; set; }

        public string SeatInfo { get; set; }
    }
}
