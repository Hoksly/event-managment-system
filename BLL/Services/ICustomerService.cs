using BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerBusinessModel>> GetAllCustomersAsync();
        Task<CustomerBusinessModel> GetCustomerByIdAsync(int customerId);
        Task CreateCustomerAsync(CustomerBusinessModel customer);
        Task UpdateCustomerAsync(CustomerBusinessModel customer);
        Task DeleteCustomerAsync(int customerId);
    }
}
