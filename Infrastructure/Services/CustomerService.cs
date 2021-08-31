using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IAsyncRepository<Customer> _asyncRepository;
        public CustomerService(IAsyncRepository<Customer> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }
        public async Task<Customer> AddCustomer(Customer model)
        {
            var entity = await _asyncRepository.AddAsync(model);
            return entity;
        }
        public async Task<Customer> DeleteCustomer(Customer model)
        {
            var entity = await _asyncRepository.DeleteAsync(model);
            return entity;
        }
        public async Task<Customer> UpdateCustomer(Customer model)
        {
            var entity = await _asyncRepository.UpdateAsync(model);
            return entity;
        }
        public async Task<List<CustomerResponseModel>> ListAllCustomers()
        {
            var customers = await _asyncRepository.ListAllAsync();
            var customerDetails = new List<CustomerResponseModel>();
            foreach(var customer in customers)
            {
                customerDetails.Add(new CustomerResponseModel
                {
                    Id = customer.Id,
                    CName = customer.CName,
                    Address = customer.Address,
                    Phone = customer.Phone,
                    Email = customer.Email,
                    RoomNo = customer.RoomId,
                    BookingDays = customer.BookingDays,
                    CheckIn = customer.CheckIn,
                    TotlePersons = customer.TotlePERSONS,
                    Advance = customer.Advance,
                    Rooms = customer.Rooms
                });
            }
            return customerDetails;
        }
    }
}
