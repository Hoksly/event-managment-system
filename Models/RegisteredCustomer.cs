namespace crm_minimal.Models
{
    public class RegisteredCustomer : Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }

        private string HashedPasswoed { get; set; }
    }
}
