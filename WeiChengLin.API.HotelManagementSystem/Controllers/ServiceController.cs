using ApplicationCore.Entities;
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
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpPost]
        [Route("addservice")]
        public async Task<IActionResult> AddRoom([FromBody] _Service model)
        {
            var entity = await _serviceService.AddService(model);
            if (entity == null)
            {
                return BadRequest("Can't add the Service at this time, something went wrong");
            }
            return Ok(entity);
        }

        [HttpDelete]
        [Route("deleteservice")]
        public async Task<IActionResult> DeleteRoom(_Service model)
        {
            var entity = await _serviceService.DeleteService(model);
            if (entity == null)
            {
                return BadRequest("No Service was found, or some inputs are incorrect");
            }
            return Ok(entity);
        }

        [HttpPut]
        [Route("updateservice")]
        public async Task<IActionResult> UpdateRoom([FromBody] _Service model)
        {
            var entity = await _serviceService.UpdateService(model);
            if (entity == null)
            {
                return BadRequest("The Service was not found, or some inputs are incorrect");
            }
            return Ok(entity);
        }

        [HttpGet]
        [Route("allservice")]
        public async Task<IActionResult> GetAllServices()
        {
            var rooms = await _serviceService.ListAllServices();
            if (!rooms.Any())
            {
                return NotFound("No Services found");
            }
            return Ok(rooms);
        }
    }
}
