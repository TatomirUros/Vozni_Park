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
    public class MineService:IMineService
    {
        private readonly IMineRepository _mineRepository;
        private readonly IVehicleRepository _vehicleRepository;
        public MineService() 
        {
            _mineRepository = new MineRepository();
            _vehicleRepository = new VehicleRepository();
        }
        public async Task<List<MineDTO>> GetAllMines()
        {
            return await _mineRepository.GetAllMinesAsync();
        }

        public async Task InsertMine(string name)
        {
            await _mineRepository.InsertMineAsync(name);
        }
        public async Task UpdateMine(int id, string name)
        {
            await _mineRepository.UpdateMineAsync(id, name);
        }
        public async Task DeleteMine(int id)
        {
            List<int> idVehicles = await _mineRepository.GetAllVehicleForMineAsync(id);
            foreach (int idVehicle in idVehicles)
            {
                await _vehicleRepository.DeleteAllConnectedWithVehicleAsync(idVehicle);
                await _vehicleRepository.DeleteVehicleAsync(idVehicle);
            }
            await _mineRepository.DeleteMineAsync(id);
        }
        
    }
}
