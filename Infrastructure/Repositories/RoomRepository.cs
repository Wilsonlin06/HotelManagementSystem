using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class RoomRepository : EfRepository<Room>, IRoomRepository
    {
        public RoomRepository(HMSDbContext dbContext): base(dbContext)
        {

        }

        public async Task<IEnumerable<Room>> GetAvailableRooms()
        {
            // Get all available rooms
            var rooms = await _dbContext.Rooms.Where(r => r.Status == true).ToListAsync();
            return rooms;
        }
        public async Task<IEnumerable<Room>> GetAvailableRoomsByType(int TypeId)
        {
            // Get all available rooms by Type
            var rooms = await _dbContext.Rooms.Where(r => r.Status == true && r.RoomTypeId == TypeId).ToListAsync();
            return rooms;
        }
        public async Task<Room> BookingRoom(Room room)
        {
            await _dbContext.Set<Room>().Where(r => r.Id == room.Id).AnyAsync();
            return room;
        }
    }
}
