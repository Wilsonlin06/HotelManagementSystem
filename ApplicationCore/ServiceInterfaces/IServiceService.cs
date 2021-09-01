using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IServiceService
    {
        Task<_Service> AddService(ServiceRequestModel model);
        Task<_Service> DeleteService(ServiceRequestModel model);
        Task<_Service> UpdateService(ServiceRequestModel model);
        Task<List<_Service>> ListAllServices();
        Task<_Service> GetServiceById(int id);
    }
}
