using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.DTOs;
using Vozni_Park.View;

namespace Vozni_Park.Repository.Interfaces
{
    public interface IVehicleRepository
    {
        Task InsertVehicleAsync(VehicleDTO vehicle);
        Task UpdateVehicleAsync(VehicleDTO vehicle);
        Task UpdatePartVehicleAsync(int id, string columnName, string columnValue);
        Task DeleteVehicleAsync(int id);
        Task DeleteAllConnectedWithVehicleAsync(int id);
        Task<VehicleDTO> GetVehicleByIdAsync(int id);
        Task<int> GetVehicleIdByRegistrationAsync(string registration);
        Task<VehicleDTO> GetVehicleByRegistrationAsync(string registration);
        Task<bool> FindRegistrationForIdAndRegistration(int id, string registration);
        Task InsertRegistration(RegistrationVehicleDTO registrationVehicle);
        Task<int> CheckVehicleCorrectnessAsync(int idVehicle);
        Task<List<VehicleRegistrationTableViewDTO>> CheckVehicleValueDateAsync(int idMine);
        Task InsertPicturesPathAsync(string newPath, int VehicleId);
        Task RegistrateVehicleAsync(int idVehicle, string dateTo);
        Task<List<VehicleTableViewDTO>> GetVehiclesByParametersAsync(int idMine, int idCategory, int idSubcategory, int idOwner, int idState);

    }
}
