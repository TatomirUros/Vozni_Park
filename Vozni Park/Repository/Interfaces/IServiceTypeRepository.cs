using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.DTOs;

namespace Vozni_Park.Repository.Interfaces
{
    public interface IServiceTypeRepository
    {
        Task<List<ServiceTypeDTO>> GetAllServiceTypesAsync();
        Task<int> GetServiceTypeIdByNameAsync(string name);
        Task InsertServiceTypeAsync(string name);
        Task UpdateServiceTypeAsync(int id, string name);
        Task DeleteServiceTypeAsync(int id);
        Task DeleteAllConnectedWithServiceTypeAsync(int id);
    }
}
