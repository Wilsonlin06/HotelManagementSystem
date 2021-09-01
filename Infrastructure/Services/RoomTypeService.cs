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
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IAsyncRepository<RoomType> _asyncRepository;
        public RoomTypeService(IAsyncRepository<RoomType> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }
        public async Task<RoomType> AddRoomType(RoomType model)
        {
            var entity = await _asyncRepository.AddAsync(model);
            return entity;
        }
        public async Task<RoomType> DeleteRoomType(RoomType model)
        {
            var entity = await _asyncRepository.DeleteAsync(model);
            return entity;
        }
        public async Task<RoomType> UpdateRoomType(RoomType model)
        {
            var entity = await _asyncRepository.UpdateAsync(model);
            return entity;
        }
        public async Task<List<RoomType>> ListAllRoomTypes()
        {
            var roomTypes = await _asyncRepository.ListAllAsync();
            var roomTypeDetails = new List<RoomType>();
            foreach (var type in roomTypes)
            {
                roomTypeDetails.Add(new RoomType
                {
                    Id = type.Id,
                    RTDesc = type.RTDesc,
                    Rent = type.Rent
                });
            }
            return roomTypeDetails;
        }

        public async Task<RoomType> GetTypeById(int id)
        {
            var roomType = await _asyncRepository.GetByIdAsync(id);
            return roomType;
        }
    }
}
