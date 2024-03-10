using System.ComponentModel.DataAnnotations;

namespace crm_minimal.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
