using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.DTOs;

namespace Vozni_Park.Services.Interfaces
{
    public interface IServiceTypeService
    {
        Task<List<ServiceTypeDTO>> GetAllServiceTypes();
        Task<int> GetServiceTypeIdByName(string name);
        Task InsertServiceType(string name);
        Task UpdateServiceType(int id, string name);
        Task DeleteServiceType(int id);
    }
}
