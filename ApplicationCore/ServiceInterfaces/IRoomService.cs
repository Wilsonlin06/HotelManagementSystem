﻿using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IRoomService
    {
        Task<RoomResponseModel> AddRoom(RoomRequestModel model);
        Task<Room> DeleteRoom(int id);
        Task<RoomRequestModel> UpdateRoom(RoomRequestModel model);
        Task<List<RoomResponseModel>> ListAllRooms();
        Task<RoomResponseModel> GetRoomById(int id);
    }
}
