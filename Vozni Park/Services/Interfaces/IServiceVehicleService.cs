using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.DTOs;

namespace Vozni_Park.Services.Interfaces
{
    public interface IServiceVehicleService
    {
        Task<List<ServiceVehicleTableViewDTO>> GetAllRequestsForVehicle(int id);
        Task DeleteServiceVehicle(int id);
        Task<int> GetServiceRequestIdForServiceId(int id);
    }
}
