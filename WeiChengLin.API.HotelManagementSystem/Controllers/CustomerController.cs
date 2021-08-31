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
        public async Task<IActionResult> AddRoom([FromBody] CustomerRequestModel model)
        {
            var entity = await _customerService.AddCustomer(model);
            if (entity == null)
            {
                return BadRequest("The type of rooms are booked");
            }
            return Ok(entity);
        }

        [HttpDelete]
        [Route("deletecustomer")]
        public async Task<IActionResult> DeleteRoom(CustomerRequestModel model)
        {
            var entity = await _customerService.DeleteCustomer(model);
            if (entity == null)
            {
                return BadRequest("No Customer was found, or some inputs are incorrect");
            }
            return Ok(entity);
        }

        [HttpPut]
        [Route("updatecustomer")]
        public async Task<IActionResult> UpdateRoom([FromBody] CustomerRequestModel model)
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
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await _customerService.ListAllCustomers();
            if (!rooms.Any())
            {
                return NotFound("No Customers found");
            }
            return Ok(rooms);
        }
    }
}
