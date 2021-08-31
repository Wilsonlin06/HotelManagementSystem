using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
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
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeService _roomTypeService;
        public RoomTypeController(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        [HttpPost]
        [Route("addroomtype")]
        public async Task<IActionResult> AddRoomType([FromBody]RoomType model)
        {
            var entity = await _roomTypeService.AddRoomType(model);
            if(entity == null)
            {
                return BadRequest("Can't add the RoomType");
            }
            return Ok(entity);
        }

        [HttpDelete]
        [Route("deleteroomtype")]
        public async Task<IActionResult> DeleteRoomType(RoomType model)
        {
            var entity = await _roomTypeService.DeleteRoomType(model);
            if(entity == null)
            {
                return BadRequest("The RoomType was not found");
            }
            return Ok(entity);
        }

        [HttpPut]
        [Route("updateroomtype")]
        public async Task<IActionResult> UpdateRoom([FromBody]RoomType model)
        {
            var entity = await _roomTypeService.UpdateRoomType(model);
            if (entity == null)
            {
                return BadRequest("The RoomType was not found, or some inputs are incorrect");
            }
            return Ok(entity);
        }

        [HttpGet]
        [Route("allrooms")]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await _roomTypeService.ListAllRoomTypes();
            if (!rooms.Any())
            {
                return NotFound("No RoomType found");
            }
            return Ok(rooms);
        }
    }
}
