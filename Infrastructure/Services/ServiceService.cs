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
    public class ServiceService : IServiceService
    {
        private readonly IAsyncRepository<_Service> _asyncRepository;
        private readonly IAsyncRepository<Room> _rAsyncRepository;
        public ServiceService(IAsyncRepository<_Service> asyncRepository, IAsyncRepository<Room> rAsyncRepository)
        {
            _asyncRepository = asyncRepository;
            _rAsyncRepository = rAsyncRepository;
        }
        public async Task<_Service> AddService(ServiceRequestModel model)
        {
            var sModel = new _Service
            {
                SDesc = model.SDesc,
                ServiceDate = model.ServiceDate,
                Amount = model.Amount,
                RoomId = model.RoomId
            };
            var entity = await _asyncRepository.AddAsync(sModel);
            return entity;
        }
        public async Task<_Service> DeleteService(int id)
        {
            var service = await _asyncRepository.DeleteByIdAsync(id);
            return service;
        }
        public async Task<_Service> UpdateService(ServiceRequestModel model)
        {
            var sModel = new _Service
            {
                Id = model.Id,
                SDesc = model.SDesc,
                ServiceDate = model.ServiceDate,
                Amount = model.Amount,
                RoomId = model.RoomId
            };
            var entity = await _asyncRepository.UpdateAsync(sModel);
            return entity;
        }
        public async Task<List<_Service>> ListAllServices()
        {
            var services = await _asyncRepository.ListAllAsync();
            var serviceDetails = new List<_Service>();
            foreach(var service in services)
            {
                var room = await _rAsyncRepository.GetByIdAsync((int)service.RoomId);
                serviceDetails.Add(new _Service 
                {
                    Id = service.Id,
                    SDesc = service.SDesc,
                    ServiceDate = service.ServiceDate,
                    Amount = service.Amount,
                    RoomId = service.RoomId,
                    Rooms = room
                });
            }
            return serviceDetails;
        }
        public async Task<_Service> GetServiceById(int id)
        {
            var service = await _asyncRepository.GetByIdAsync(id);
            var room = await _rAsyncRepository.GetByIdAsync((int)service.RoomId);
            var serviceDetails = new _Service
            {
                Id = service.Id,
                SDesc = service.SDesc,
                ServiceDate = service.ServiceDate,
                Amount = service.Amount,
                RoomId = service.RoomId,
                Rooms = room
            };
            return serviceDetails;
        }
    }
}
