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
        public ServiceService(IAsyncRepository<_Service> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }
        public async Task<_Service> AddService(_Service model)
        {
            var entity = await _asyncRepository.AddAsync(model);
            return entity;
        }
        public async Task<_Service> DeleteService(_Service model)
        {
            var entity = await _asyncRepository.DeleteAsync(model);
            return entity;
        }
        public async Task<_Service> UpdateService(_Service model)
        {
            var entity = await _asyncRepository.UpdateAsync(model);
            return entity;
        }
        public async Task<List<ServiceResponseModel>> ListAllServices()
        {
            var services = await _asyncRepository.ListAllAsync();
            var serviceDetails = new List<ServiceResponseModel>();
            foreach(var service in services)
            {
                serviceDetails.Add(new ServiceResponseModel 
                {
                    Id = service.Id,
                    SDesc = service.SDesc,
                    ServiceDate = service.ServiceDate,
                    Amount = service.Amount,
                    RoomId = service.RoomId,
                    Rooms = service.Rooms
                });
            }
            return serviceDetails;
        }
    }
}
