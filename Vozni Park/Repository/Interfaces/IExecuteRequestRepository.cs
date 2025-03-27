using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.DTOs;

namespace Vozni_Park.Repository.Interfaces
{
    public interface IExecuteRequestRepository
    {
        Task ExecuteRequestAsync(ExecuteRequestDTO executeRequest);
        Task UpdateExecutedRequestAsync(ExecuteRequestDTO executeRequest);
        Task InsertPictureAsync(string newPath, int id);
        Task<int> GetMaxIdExecuteAsync();
        Task<int> GetRequestIdByServiceVehicleIdAsync(int serviceVehicleId);
    }
}
