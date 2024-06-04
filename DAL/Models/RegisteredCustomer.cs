using Microsoft.AspNetCore.Identity;

namespace crm_minimal.Models
{
    public class RegisteredCustomer : IdentityUser
    {
        public string Name { get; set; }
        public string Email { get; set; }

        private string HashedPasswoed { get; set; }
    }
}
