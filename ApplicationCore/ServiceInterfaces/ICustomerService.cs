using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface ICustomerService
    {
        Task<CustomerResponseModel> AddCustomer(CustomerRequestModel model);
        Task<Customer> DeleteCustomer(int id);
        Task<CustomerResponseModel> UpdateCustomer(CustomerRequestModel model);
        Task<List<CustomerResponseModel>> ListAllCustomers();
        Task<CustomerResponseModel> GetCustomerById(int id);
    }
}
