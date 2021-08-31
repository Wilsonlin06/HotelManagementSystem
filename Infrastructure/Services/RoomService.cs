﻿using ApplicationCore.Entities;
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
        private readonly IAsyncRepository<RoomType> _rtAsyncRepository;
        private readonly IAsyncRepository<_Service> _sAsyncRepository;
        public RoomService(IAsyncRepository<Room> asyncRepository, IAsyncRepository<RoomType> rtAsyncRepository, IAsyncRepository<_Service> sAsyncRepository)
        {
            _asyncRepository = asyncRepository;
            _rtAsyncRepository = rtAsyncRepository;
            _sAsyncRepository = sAsyncRepository;
        }
        public async Task<RoomResponseModel> AddRoom(RoomRequestModel model)
        {
            // Find the RoomType and add into roomModel
            //var types = await _rtAsyncRepository.ListAllAsync();
            //var rType = new RoomType { };
            //foreach(var type in types)
            //{
            //    if(type.Id == model.RTCode)
            //    {
            //        rType.Id = type.Id;
            //        rType.Rent = type.Rent;
            //        rType.RTDesc = type.RTDesc;
            //    }
            //}
            var roomModel = new Room
            {
                Id = model.RoomNo,
                RoomTypeId = model.RTCode,
                Status = model.Status,
                //RoomTypes = rType
            };
            var entity = await _asyncRepository.AddAsync(roomModel);
            if(entity != null)
            {
                var room = new RoomResponseModel
                {
                    RoomNo = entity.Id,
                    RTCode = entity.RoomTypeId,
                    Status = entity.Status,
                    RoomTypes = entity.RoomTypes
                };
                room.Services = new List<ServiceResponseModel>();
                if (entity.Services != null) { }
                else
                {
                    foreach (var service in room.Services)
                    {
                        room.Services.Add(new ServiceResponseModel
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
                return room;
            }
            return null;
        }
        public async Task<RoomRequestModel> DeleteRoom(RoomRequestModel model)
        {
            var roomModel = new Room
            {
                Id = model.RoomNo,
                RoomTypeId = model.RTCode,
                Status = model.Status
            };
            var entity = await _asyncRepository.DeleteAsync(roomModel);
            if(entity != null) return model;
            return null;
        }
        public async Task<RoomRequestModel> UpdateRoom(RoomRequestModel model)
        {
            var roomModel = new Room
            {
                Id = model.RoomNo,
                RoomTypeId = model.RTCode,
                Status = model.Status
            };
            var entity = await _asyncRepository.UpdateAsync(roomModel);
            if(entity != null) return model;
            return null;
        }
        public async Task<List<RoomResponseModel>> ListAllRooms()
        {
            var rooms = await _asyncRepository.ListAllAsync();
            var roomList = new List<RoomResponseModel>();
            foreach(var room in rooms)
            {
                var newRoom = new RoomResponseModel
                {
                    RoomNo = room.Id,
                    RTCode = room.RoomTypeId,
                    RoomTypes = room.RoomTypes,
                    Status = room.Status
                };
                
                if (room.Services == null) { }
                else
                {
                    newRoom.Services = new List<ServiceResponseModel>();
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
