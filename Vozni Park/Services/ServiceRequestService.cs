using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.Repository.Interfaces;
using Vozni_Park.Repository;
using Vozni_Park.Services.Interfaces;
using Vozni_Park.DTOs;

namespace Vozni_Park.Services
{
    internal class ServiceRequestService : IServiceRequestService
    {
        private readonly IServiceRequestRepository _serviceRequestRepository;
        public ServiceRequestService()
        {
            _serviceRequestRepository = new ServiceRequestRepository();
        }
        public async Task InsertServiceRequest(ServiceRequestDTO serviceRequest)
        {
            await _serviceRequestRepository.InsertServiceRequestAsync(serviceRequest);
        }
        public async Task DeleteServiceRequest(int id)
        {
            await _serviceRequestRepository.DeleteAllConnectedWithServiceRequestAsync(id);
            await _serviceRequestRepository.DeleteServiceRequestAsync(id);
        }
        public async Task<List<ServiceRequestTableViewDTO>> GetAllRequestsForVehicle(int id)
        {
            return await _serviceRequestRepository.GetAllRequestsForVehicleAsync(id);
        }

        public async Task InsertPicture(string newPath, int id)
        {
            await _serviceRequestRepository.InsertPictureAsync(newPath, id);
        }

        public Task<ServiceRequestShowDetailsDTO> GetRequestForRequestId(int id)
        {
            return _serviceRequestRepository.GetRequestForRequestIdAsync(id);
        }
        public Task<int> GetVehicleIdForRequestId(int id)
        {
            return _serviceRequestRepository.GetVehicleIdForRequestIdAsync(id);
        }

    }
}
