using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.DTOs;
using Vozni_Park.Repository.Interfaces;
using Vozni_Park.Repository;
using Vozni_Park.Services.Interfaces;

namespace Vozni_Park.Services
{
    public class ServiceTypeService : IServiceTypeService
    {
        private readonly IServiceTypeRepository _serviceTypeRepository;
        public ServiceTypeService()
        {
            _serviceTypeRepository = new ServiceTypeRepository();
        }

        public async Task<List<ServiceTypeDTO>> GetAllServiceTypes()
        {
            return await _serviceTypeRepository.GetAllServiceTypesAsync();
        }

        public async Task<int> GetServiceTypeIdByName(string name)
        {
            return await _serviceTypeRepository.GetServiceTypeIdByNameAsync(name);
        }

        public async Task InsertServiceType(string name)
        {
            await _serviceTypeRepository.InsertServiceTypeAsync(name);
        }

        public async Task UpdateServiceType(int id, string name)
        {
            await _serviceTypeRepository.UpdateServiceTypeAsync(id, name);
        }

        public async Task DeleteServiceType(int id)
        {
            await _serviceTypeRepository.DeleteAllConnectedWithServiceTypeAsync(id);
            await _serviceTypeRepository.DeleteServiceTypeAsync(id);
        }

    }
}
