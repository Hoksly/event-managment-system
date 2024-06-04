using crm_minimal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace crm_minimal.DAL.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<RegisteredCustomer?>> GetAllCustomersAsync();
        Task<RegisteredCustomer?> GetCustomerByIdAsync(int customerId);
        Task AddCustomerAsync(RegisteredCustomer? customer);
        Task UpdateCustomerAsync(RegisteredCustomer? customer);
        Task DeleteCustomerAsync(int customerId);
    }
}
