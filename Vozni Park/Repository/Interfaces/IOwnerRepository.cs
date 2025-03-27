using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.DTOs;

namespace Vozni_Park.Repository.Interfaces
{
    public interface IOwnerRepository
    {
        Task<List<OwnerDTO>> GetAllOwnersAsync();
        Task InsertOwnerAsync(string name);
        Task UpdateOwnerAsync(int id, string name);
        Task DeleteOwnerAsync(int id);
        Task<List<int>> GetAllVehicleForOwnerAsync(int id);
    }
}
