using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.DTOs;

namespace Vozni_Park.Repository.Interfaces
{
    public interface IServiceRequestRepository
    {
        Task InsertServiceRequestAsync(ServiceRequestDTO serviceRequest);
        Task DeleteServiceRequestAsync(int id);
        Task DeleteAllConnectedWithServiceRequestAsync(int id);
        Task<List<ServiceRequestTableViewDTO>> GetAllRequestsForVehicleAsync(int id);
        Task InsertPictureAsync(string newPath, int id);
        Task<ServiceRequestShowDetailsDTO> GetRequestForRequestIdAsync(int id);
        Task<int> GetVehicleIdForRequestIdAsync(int id);
    }
}
