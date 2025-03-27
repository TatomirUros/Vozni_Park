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
    public class OwnerService:IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IVehicleRepository _vehicleRepository;
        public OwnerService()
        {
            _ownerRepository = new OwnerRepository();
            _vehicleRepository = new VehicleRepository();
        }
        public async Task<List<OwnerDTO>> GetAllOwners()
        {
            return await _ownerRepository.GetAllOwnersAsync();
        }
        
        public async Task InsertOwner(string name)
        {
            await _ownerRepository.InsertOwnerAsync(name);
        }
        public async Task UpdateOwner(int id, string name)
        {
            await _ownerRepository.UpdateOwnerAsync(id, name);
        }
        public async Task DeleteOwner(int id)
        {
            List<int> idVehicles = await _ownerRepository.GetAllVehicleForOwnerAsync(id);
            foreach (int idVehicle in idVehicles) 
            {
                await _vehicleRepository.DeleteAllConnectedWithVehicleAsync(idVehicle);
                await _vehicleRepository.DeleteVehicleAsync(idVehicle);
            }
            await _ownerRepository.DeleteOwnerAsync(id);
        }

    }
}
