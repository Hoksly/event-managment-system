using BLL.Models;
using BLL.Utils;
using crm_minimal.DAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using crm_minimal.Models;

namespace BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<CustomerBusinessModel>> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAllCustomersAsync();
            return customers.Select(Mapper.MapToBusinessModel);
        }

        public async Task<CustomerBusinessModel> GetCustomerByIdAsync(int customerId)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(customerId);
            return Mapper.MapToBusinessModel(customer);
        }

        public async Task CreateCustomerAsync(CustomerBusinessModel customer)
        {
            var dataModel = Mapper.MapToDataModel(customer);
            await _customerRepository.AddCustomerAsync(dataModel);
        }

        public async Task UpdateCustomerAsync(CustomerBusinessModel customer)
        {
            var dataModel = Mapper.MapToDataModel(customer);
            await _customerRepository.UpdateCustomerAsync(dataModel);
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            await _customerRepository.DeleteCustomerAsync(customerId);
        }
    }
}
