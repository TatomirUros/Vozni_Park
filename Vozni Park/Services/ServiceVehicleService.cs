using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.DTOs;
using Vozni_Park.Repository;
using Vozni_Park.Repository.Interfaces;
using Vozni_Park.Services.Interfaces;

namespace Vozni_Park.Services
{
    public class ServiceVehicleService : IServiceVehicleService
    {
        private readonly IServiceVehicleRepository _serviceVehicle;
        public ServiceVehicleService() 
        { 
            _serviceVehicle = new ServiceVehicleRepository();
        }

        public async Task DeleteServiceVehicle(int id)
        {
            int idRequest = await _serviceVehicle.FindIdRequestForServiceIdAsync(id);
            await _serviceVehicle.UpdateStatusOfRequestAsync(idRequest);
            await _serviceVehicle.DeleteAllConnectedWithServiceVehicleAsync(id);
            await _serviceVehicle.DeleteServiceVehicleAsync(id);
        }

        public async Task<List<ServiceVehicleTableViewDTO>> GetAllRequestsForVehicle(int id)
        {
            return await _serviceVehicle.GetAllRequestsForVehicleAsync(id);
        }

        public async Task<int> GetServiceRequestIdForServiceId(int id)
        {
            return await _serviceVehicle.GetServiceRequestIdForServiceIdAsync(id);
        }
    }
}
