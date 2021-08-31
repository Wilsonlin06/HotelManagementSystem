using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IRoomRepository : IAsyncRepository<Room>
    {
        Task<IEnumerable<Room>> GetAvailableRooms();
        Task<IEnumerable<Room>> GetAvailableRoomsByType(int TypeId);
        Task<Room> BookingRoom(Room room);
    }
}
