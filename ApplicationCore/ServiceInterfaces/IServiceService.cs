using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IServiceService
    {
        Task<_Service> AddService(_Service model);
        Task<_Service> DeleteService(_Service model);
        Task<_Service> UpdateService(_Service model);
        Task<List<_Service>> ListAllServices();
    }
}
