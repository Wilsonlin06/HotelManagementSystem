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
        private readonly IAsyncRepository<Room> _rmAsyncRepository;
        public CustomerService(IAsyncRepository<Customer> asyncRepository, IAsyncRepository<Room> rmAsyncRepository)
        {
            _asyncRepository = asyncRepository;
            _rmAsyncRepository = rmAsyncRepository;
        }
        public async Task<CustomerResponseModel> AddCustomer(CustomerRequestModel model)
        {
            var cModel = new Customer 
            {
                RoomId = model.RoomId,
                CName = model.CName,
                Address = model.Address,
                Phone = model.Phone,
                Email = model.Email,
                BookingDays = model.BookingDays,
                Advance = model.Advance,
                CheckIn = model.CheckIn,
                TotalPERSONS = model.TotalPERSONS
            };
            var room = await _rmAsyncRepository.GetByIdAsync((int)model.RoomId);
            if (room.Status == false) return null;
            var entity = await _asyncRepository.AddAsync(cModel);
            var customer = new CustomerResponseModel
            {
                Id = entity.Id,
                CName = entity.CName,
                Address = entity.Address,
                Phone = entity.Phone,
                Email = entity.Email,
                RoomNo = entity.RoomId,
                BookingDays = entity.BookingDays,
                TotalPersons = entity.TotalPERSONS,
                CheckIn = entity.CheckIn,
                Advance = entity.Advance
            };
            return customer;
        }
        public async Task<Customer> DeleteCustomer(int id)
        {
            var customer = await _asyncRepository.DeleteByIdAsync(id);
            return customer;
        }
        public async Task<CustomerResponseModel> UpdateCustomer(CustomerRequestModel model)
        {
            var cModel = new Customer
            {
                Id = model.id,
                RoomId = model.RoomId,
                CName = model.CName,
                Address = model.Address,
                Phone = model.Phone,
                Email = model.Email,
                BookingDays = model.BookingDays,
                Advance = model.Advance,
                CheckIn = model.CheckIn,
                TotalPERSONS = model.TotalPERSONS
            };
            var entity = await _asyncRepository.UpdateAsync(cModel);
            var customer = new CustomerResponseModel
            {
                Id = entity.Id,
                CName = entity.CName,
                Address = entity.Address,
                Phone = entity.Phone,
                Email = entity.Email,
                RoomNo = entity.RoomId,
                BookingDays = entity.BookingDays,
                TotalPersons = entity.TotalPERSONS,
                CheckIn = entity.CheckIn,
                Advance = entity.Advance
            };
            return customer;
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
                    TotalPersons = customer.TotalPERSONS,
                    Advance = customer.Advance
                });
            }
            return customerDetails;
        }

        public async Task<CustomerResponseModel> GetCustomerById(int id)
        {
            var customer = await _asyncRepository.GetByIdAsync(id);
            var customerDetails = new CustomerResponseModel
            {
                Id = customer.Id,
                CName = customer.CName,
                Address = customer.Address,
                Phone = customer.Phone,
                Email = customer.Email,
                RoomNo = customer.RoomId,
                BookingDays = customer.BookingDays,
                CheckIn = customer.CheckIn,
                TotalPersons = customer.TotalPERSONS,
                Advance = customer.Advance
            };
            return customerDetails;
        }
    }
}
