using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.DTOs;

namespace Vozni_Park.Services.Interfaces
{
    internal interface IServiceRequestService
    {
        Task InsertServiceRequest(ServiceRequestDTO serviceRequest);
        Task DeleteServiceRequest(int id);
        Task<List<ServiceRequestTableViewDTO>> GetAllRequestsForVehicle(int id);
        Task InsertPicture(string newPath, int id);
        Task<ServiceRequestShowDetailsDTO> GetRequestForRequestId(int id);
        Task<int> GetVehicleIdForRequestId(int id);
    }
}
