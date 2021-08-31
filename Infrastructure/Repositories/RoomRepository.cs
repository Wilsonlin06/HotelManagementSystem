using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Models;

namespace Infrastructure.Repositories
{
    public class RoomRepository : EfRepository<RoomRequestModel>, IRoomRepository
    {
        public RoomRepository(HMSDbContext dbContext): base(dbContext)
        {

        }

        public async Task<IEnumerable<RoomResponseModel>> GetAvailableRooms()
        {
            // Get all available rooms
            var rooms = await _dbContext.Rooms.Include(t => t.Services.Any(s => s.RoomId == t.Id)).Include(t => t.RoomTypes).Where(r => r.RoomTypeId == r.RoomTypes.Id && r.Status == true).ToListAsync();
            var roomList = new List<RoomResponseModel>();
            foreach(var room in rooms)
            {
                var newRoom = new RoomResponseModel
                {
                    RoomNo = room.Id,
                    RoomTypes = room.RoomTypes,
                    RTCode = room.RoomTypes.Id,
                    Status = room.Status
                };
                newRoom.Services = new List<ServiceResponseModel>();
                if (!room.Services.Any()) { }
                else
                {
                    foreach (var service in room.Services)
                    {
                        newRoom.Services.Add(new ServiceResponseModel
                        {
                            Id = service.Id,
                            SDesc = service.SDesc,
                            ServiceDate = service.ServiceDate,
                            Amount = service.Amount,
                            RoomId = service.RoomId,
                            Rooms = service.Rooms
                        });
                    }
                }
                roomList.Add(newRoom);
            }
            return roomList;
        }
        public async Task<IEnumerable<RoomResponseModel>> GetAvailableRoomsByType(int TypeId)
        {
            // Get all available rooms by Type
            var rooms = await _dbContext.Rooms.Where(r => r.Status == true && r.RoomTypeId == TypeId).ToListAsync();
            var roomList = new List<RoomResponseModel>();
            foreach(var room in rooms)
            {
                var newRoom = new RoomResponseModel
                {
                    RoomNo = room.Id,
                    RTCode = room.RoomTypeId,
                    Status = room.Status,
                    RoomTypes = room.RoomTypes
                };
                newRoom.Services = new List<ServiceResponseModel>();
                if (!room.Services.Any()) { }
                else
                {
                    foreach (var service in room.Services)
                    {
                        newRoom.Services.Add(new ServiceResponseModel
                        {
                            Id = service.Id,
                            SDesc = service.SDesc,
                            ServiceDate = service.ServiceDate,
                            Amount = service.Amount,
                            RoomId = service.RoomId,
                            Rooms = service.Rooms
                        });
                    }
                }
                roomList.Add(newRoom);
            }
            return roomList;
        }
        public async Task<Room> BookingRoom(Room room)
        {
            await _dbContext.Set<Room>().Where(r => r.Id == room.Id).AnyAsync();
            return room;
        }

        public async Task<RoomResponseModel> AddRoom(RoomRequestModel model)
        {
            var entity = await _dbContext.AddAsync(model);
            var room = await _dbContext.Rooms.FirstOrDefaultAsync(r => r.Id == entity.Entity.RoomNo);
            var roomDetails = new RoomResponseModel
            {
                RoomNo = room.Id,
                RTCode = room.RoomTypeId,
                Status = room.Status,
                RoomTypes = room.RoomTypes
            };
            roomDetails.Services = new List<ServiceResponseModel>();
            if (!room.Services.Any()) { }
            else
            {
                foreach (var service in room.Services)
                {
                    roomDetails.Services.Add(new ServiceResponseModel
                    {
                        Id = service.Id,
                        SDesc = service.SDesc,
                        ServiceDate = service.ServiceDate,
                        Amount = service.Amount,
                        RoomId = service.RoomId,
                        Rooms = service.Rooms
                    });
                }
            }
            return roomDetails;
        }

        public async Task<IEnumerable<RoomResponseModel>> ListAllRooms()
        {
            var rooms = await _dbContext.Rooms.ToListAsync();
            var roomList = new List<RoomResponseModel>();
            foreach (var room in rooms)
            {
                var newRoom = new RoomResponseModel
                {
                    RoomNo = room.Id,
                    RoomTypes = room.RoomTypes,
                    RTCode = room.RoomTypes.Id,
                    Status = room.Status
                };
                newRoom.Services = new List<ServiceResponseModel>();
                if (room.Services != null) { }
                else
                {
                    foreach (var service in room.Services)
                    {
                        newRoom.Services.Add(new ServiceResponseModel
                        {
                            Id = service.Id,
                            SDesc = service.SDesc,
                            ServiceDate = service.ServiceDate,
                            Amount = service.Amount,
                            RoomId = service.RoomId,
                            Rooms = service.Rooms
                        });
                    }
                }
                roomList.Add(newRoom);
            }
            return roomList;
        }
    }
}
