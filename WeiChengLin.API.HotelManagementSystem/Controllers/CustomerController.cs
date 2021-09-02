using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeiChengLin.API.HotelManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        [Route("addcustomer")]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerRequestModel model)
        {
            var entity = await _customerService.AddCustomer(model);
            if (entity == null)
            {
                return BadRequest("The type of rooms are booked");
            }
            return Ok(entity);
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var entity = await _customerService.DeleteCustomer(id);
            if (entity == null)
            {
                return BadRequest("No Customer was found, or some inputs are incorrect");
            }
            return Ok(entity);
        }

        [HttpPut]
        [Route("updatecustomer")]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerRequestModel model)
        {
            var entity = await _customerService.UpdateCustomer(model);
            if (entity == null)
            {
                return BadRequest("The Customer was not found, or some inputs are incorrect");
            }
            return Ok(entity);
        }

        [HttpGet]
        [Route("allcustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerService.ListAllCustomers();
            if (!customers.Any())
            {
                return NotFound("No Customers found");
            }
            return Ok(customers);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound("Customer was not found");
            }
            return Ok(customer);
        }
    }
}
