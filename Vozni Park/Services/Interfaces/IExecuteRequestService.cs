using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.DTOs;

namespace Vozni_Park.Services.Interfaces
{
    internal interface IExecuteRequestService
    {
        Task ExecuteRequest(ExecuteRequestDTO executeRequest);
        Task UpdateExecutedRequest(ExecuteRequestDTO executeRequest);
        Task InsertPicture(string newPath, int id);
        Task<int> GetMaxIdExecute();
        Task<int> GetRequestIdByServiceVehicleId(int serviceVehicleId);
    }
}
