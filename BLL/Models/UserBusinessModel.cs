namespace BLL.Models
{
    public class UserBusinessModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        // Other properties as needed

        // Additional business logic properties
        public bool IsEmailVerified { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
