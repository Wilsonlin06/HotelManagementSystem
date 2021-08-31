using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IRoomRepository : IAsyncRepository<RoomRequestModel>
    {
        Task<IEnumerable<RoomResponseModel>> ListAllRooms();
        Task<IEnumerable<RoomResponseModel>> GetAvailableRooms();
        Task<IEnumerable<RoomResponseModel>> GetAvailableRoomsByType(int TypeId);
        Task<RoomResponseModel> AddRoom(RoomRequestModel model);
        //Task<RoomResponseModel> UpdateRoom(RoomRequestModel model);
        //Task<RoomRequestModel> DeleteRoom(Room)
    }
}
