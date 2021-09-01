using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IRoomTypeService
    {
        Task<RoomType> AddRoomType(RoomType model);
        Task<RoomType> DeleteRoomType(RoomType model);
        Task<RoomType> UpdateRoomType(RoomType model);
        Task<List<RoomType>> ListAllRoomTypes();
        Task<RoomType> GetTypeById(int id);
    }
}
