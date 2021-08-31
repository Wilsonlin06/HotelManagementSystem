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
        Task<Customer> AddCustomer(CustomerRequestModel model);
        Task<Customer> DeleteCustomer(CustomerRequestModel model);
        Task<Customer> UpdateCustomer(CustomerRequestModel model);
        Task<List<Customer>> ListAllCustomers();
    }
}
