using crm_minimal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace crm_minimal.DAL.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer?>> GetAllCustomersAsync();
        Task<Customer?> GetCustomerByIdAsync(int customerId);
        Task AddCustomerAsync(Customer? customer);
        Task UpdateCustomerAsync(Customer? customer);
        Task DeleteCustomerAsync(int customerId);
    }
}
