using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.DTOs;
using Vozni_Park.View;

namespace Vozni_Park.Repository.Interfaces
{
    public interface IMineRepository
    {
        Task<List<MineDTO>> GetAllMinesAsync();
        Task InsertMineAsync(string name);
        Task UpdateMineAsync(int id, string name);
        Task DeleteMineAsync(int id);
        Task<List<int>> GetAllVehicleForMineAsync(int id);
    }
}
