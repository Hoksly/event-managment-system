namespace BLL.Models
{
    public class RegisteredCustomerBusinessModel : CustomerBusinessModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        // Avoid exposing sensitive data like passwords in business models
    }

}
