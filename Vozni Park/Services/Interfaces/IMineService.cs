using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.DTOs;

namespace Vozni_Park.Services.Interfaces
{
    public interface IMineService
    {
        Task<List<MineDTO>> GetAllMines();
        Task InsertMine(string name);
        Task UpdateMine(int id, string name);
        Task DeleteMine(int id);
    }
}
