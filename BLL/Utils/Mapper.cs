using BLL.Models;
using crm_minimal.Models;

namespace BLL.Utils
{
    public static class Mapper
    {
        public static CustomerBusinessModel MapToBusinessModel(Customer? customer)
        {
            return new CustomerBusinessModel
            {
                Id = customer.Id,
                CreatedAt = customer.CreatedAt
            };
        }

        public static Customer? MapToDataModel(CustomerBusinessModel customerBusinessModel)
        {
            return new Customer
            {
                Id = customerBusinessModel.Id,
                CreatedAt = customerBusinessModel.CreatedAt
            };
        }

        // Similar mapping methods for other models
    }

}
