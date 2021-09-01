using ApplicationCore.Entities;
using ApplicationCore.Models;
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
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
                
        [HttpPost]
        [Route("addroom")]
        public async Task<IActionResult> AddRoom([FromBody]RoomRequestModel model)
        {
            var entity = await _roomService.AddRoom(model);
            if(entity == null)
            {
                return BadRequest("Can't add the Room at this time, something went wrong");
            }
            return Ok(entity);
        }

        [HttpDelete]
        [Route("deleteroom")]
        public async Task<IActionResult> DeleteRoom(RoomRequestModel model)
        {
            var entity = await _roomService.DeleteRoom(model);
            if (entity == null)
            {
                return BadRequest("No Room was found, or some inputs are incorrect");
            }
            return Ok(entity);
        }

        [HttpPut]
        [Route("updateroom")]
        public async Task<IActionResult> UpdateRoom([FromBody] RoomRequestModel model)
        {
            var entity = await _roomService.UpdateRoom(model);
            if(entity == null)
            {
                return BadRequest("The Room was not found, or some inputs are incorrect");
            }
            return Ok(entity);
        }

        [HttpGet]
        [Route("allrooms")]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await _roomService.ListAllRooms();
            if (!rooms.Any())
            {
                return NotFound("No Rooms found");
            }
            return Ok(rooms);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            var room = await _roomService.GetRoomById(id);
            if (room == null)
            {
                return NotFound("The room was not found");
            }
            return Ok(room);
        }
    }
}
