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
    public class RoomService : IRoomService
    {
        private readonly IAsyncRepository<Room> _asyncRepository;
        public RoomService(IAsyncRepository<Room> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }
        public async Task<Room> AddRoom(Room model)
        {
            var entity = await _asyncRepository.AddAsync(model);
            return entity;
        }
        public async Task<Room> DeleteRoom(Room model)
        {
            var entity = await _asyncRepository.DeleteAsync(model);
            return entity;
        }
        public async Task<Room> UpdateRoom(Room model)
        {
            var entity = await _asyncRepository.UpdateAsync(model);
            return entity;
        }
        public async Task<List<RoomResponseModel>> ListAllRooms()
        {
            var rooms = await _asyncRepository.ListAllAsync();
            var roomDetails = new List<RoomResponseModel>();
            foreach(var room in rooms)
            {
                var newRoom = new RoomResponseModel 
                {
                    RoomNo = room.Id,
                    Status = (bool)room.Status,
                    RTCode = (int)room.RoomTypeId,
                    RoomTypes = room.RoomTypes
                };
                newRoom.Services = new List<ServiceResponseModel>();
                foreach(var service in room.Services)
                {
                    newRoom.Services.Add(new ServiceResponseModel
                    {
                        Id = service.Id,
                        SDesc = service.SDesc,
                        ServiceDate = service.ServiceDate,
                        RoomId = service.RoomId,
                        Amount = service.Amount,
                        Rooms = service.Rooms
                    });
                }
                roomDetails.Add(newRoom);
            }
            return roomDetails;
        }
    }
}
