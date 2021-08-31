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
        public async Task<Customer> AddCustomer(CustomerRequestModel model)
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
                TotlePERSONS = model.TotlePERSONS
            };
            var room = await _rmAsyncRepository.GetByIdAsync((int)model.RoomId);
            if (room.Status == false) return null;
            var entity = await _asyncRepository.AddAsync(cModel);
            return entity;
        }
        public async Task<Customer> DeleteCustomer(CustomerRequestModel model)
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
                TotlePERSONS = model.TotlePERSONS
            };
            var entity = await _asyncRepository.DeleteAsync(cModel);
            return entity;
        }
        public async Task<Customer> UpdateCustomer(CustomerRequestModel model)
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
                TotlePERSONS = model.TotlePERSONS
            };
            var entity = await _asyncRepository.UpdateAsync(cModel);
            return entity;
        }
        public async Task<List<Customer>> ListAllCustomers()
        {
            var customers = await _asyncRepository.ListAllAsync();
            var customerDetails = new List<Customer>();
            foreach(var customer in customers)
            {
                customerDetails.Add(new Customer
                {
                    Id = customer.Id,
                    CName = customer.CName,
                    Address = customer.Address,
                    Phone = customer.Phone,
                    Email = customer.Email,
                    RoomId = customer.RoomId,
                    BookingDays = customer.BookingDays,
                    CheckIn = customer.CheckIn,
                    TotlePERSONS = customer.TotlePERSONS,
                    Advance = customer.Advance,
                    Rooms = customer.Rooms
                });
            }
            return customerDetails;
        }
    }
}
