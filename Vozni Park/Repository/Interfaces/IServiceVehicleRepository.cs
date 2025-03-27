using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.DTOs;

namespace Vozni_Park.Repository.Interfaces
{
    internal interface IServiceVehicleRepository
    {
        Task<List<ServiceVehicleTableViewDTO>> GetAllRequestsForVehicleAsync(int id);
        Task DeleteServiceVehicleAsync(int id);
        Task DeleteAllConnectedWithServiceVehicleAsync(int id);
        Task<int> FindIdRequestForServiceIdAsync(int id);
        Task UpdateStatusOfRequestAsync(int idRequest);
        Task<int> GetServiceRequestIdForServiceIdAsync(int id);
    }
}
