using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.DTOs;

namespace Vozni_Park.Services.Interfaces
{
    public interface IRepairerService
    {
        Task<List<RepairerDTO>> GetAllRepairers();
        Task<int> GetRepairerIdByName(string name);
        Task InsertRepairer(string name);
        Task UpdateRepairer(int id, string name);
        Task DeleteRepairer(int id);
    }
}
