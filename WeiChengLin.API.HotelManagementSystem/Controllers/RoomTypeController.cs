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
        [Route("delete/{id:int}")]
        public async Task<IActionResult> DeleteRoomType(int id)
        {
            var entity = await _roomTypeService.DeleteRoomType(id);
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
        [Route("alltypes")]
        public async Task<IActionResult> GetAllRooms()
        {
            var roomTypes = await _roomTypeService.ListAllRoomTypes();
            if (!roomTypes.Any())
            {
                return NotFound("No RoomType found");
            }
            return Ok(roomTypes);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetTypeById(int id)
        {
            var type = await _roomTypeService.GetTypeById(id);
            if (type == null)
            {
                return NotFound("The RoomType was not found");
            }
            return Ok(type);
        }
    }
}
