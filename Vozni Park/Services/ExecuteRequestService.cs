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
    internal class ExecuteRequestService : IExecuteRequestService
    {
        private readonly IExecuteRequestRepository _executeRequestRepository;

        public ExecuteRequestService()
        {
            _executeRequestRepository =new ExecuteRequestRepository();
        }

        public async Task ExecuteRequest(ExecuteRequestDTO executeRequest)
        {
            await _executeRequestRepository.ExecuteRequestAsync(executeRequest);
        }

        public async Task UpdateExecutedRequest(ExecuteRequestDTO executeRequest)
        {
            await _executeRequestRepository.UpdateExecutedRequestAsync(executeRequest);
        }

        public async Task InsertPicture(string newPath, int id)
        {
            await _executeRequestRepository.InsertPictureAsync(newPath, id);
        }

        public async Task<int> GetMaxIdExecute()
        {
            return await _executeRequestRepository.GetMaxIdExecuteAsync();
        }

        public async Task<int> GetRequestIdByServiceVehicleId(int serviceVehicleId)
        {
            return await _executeRequestRepository.GetRequestIdByServiceVehicleIdAsync(serviceVehicleId);
        }

    }
}
