using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace crm_minimal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomersAsync()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] CustomerBusinessModel customer)
        {
            await _customerService.CreateCustomerAsync(customer);
            return CreatedAtAction(nameof(GetCustomerByIdAsync), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerAsync(int id, [FromBody] CustomerBusinessModel customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }
            await _customerService.UpdateCustomerAsync(customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerAsync(int id)
        {
            await _customerService.DeleteCustomerAsync(id);
            return NoContent();
        }
    }
}
