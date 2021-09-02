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
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpPost]
        [Route("addservice")]
        public async Task<IActionResult> AddRoom([FromBody] ServiceRequestModel model)
        {
            var entity = await _serviceService.AddService(model);
            if (entity == null)
            {
                return BadRequest("Can't add the Service at this time, something went wrong");
            }
            return Ok(entity);
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var entity = await _serviceService.DeleteService(id);
            if (entity == null)
            {
                return BadRequest("No Service was found, or some inputs are incorrect");
            }
            return Ok(entity);
        }

        [HttpPut]
        [Route("updateservice")]
        public async Task<IActionResult> UpdateRoom([FromBody] ServiceRequestModel model)
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
            var services = await _serviceService.ListAllServices();
            if (!services.Any())
            {
                return NotFound("No Services found");
            }
            return Ok(services);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            var service = await _serviceService.GetServiceById(id);
            if (service == null)
            {
                return NotFound("The Service was not found");
            }
            return Ok(service);
        }
    }
}
