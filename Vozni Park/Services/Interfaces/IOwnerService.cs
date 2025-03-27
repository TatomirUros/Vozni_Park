using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.DTOs;

namespace Vozni_Park.Services.Interfaces
{
    public interface IOwnerService
    {
        Task<List<OwnerDTO>> GetAllOwners();
        Task InsertOwner(string name);
        Task UpdateOwner(int id, string name);
        Task DeleteOwner(int id);
    }
}
