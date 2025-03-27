using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.DTOs;

namespace Vozni_Park.Repository.Interfaces
{
    public interface IRepairerRepository
    {
        Task<List<RepairerDTO>> GetAllRepairersAsync();
        Task<int> GetRepairerIdByNameAsync(string name);
        Task InsertRepairerAsync(string name);
        Task UpdateRepairerAsync(int id, string name);
        Task DeleteRepairerAsync(int id);
        Task DeleteAllConnectedWithRepairerAsync(int id);
    }
}
