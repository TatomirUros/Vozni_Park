using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.DTOs;
using Vozni_Park.View;

namespace Vozni_Park.Services.Interfaces
{
    public interface IVehicleService
    {
        Task InsertVehicle(VehicleDTO vehicle);
        Task UpdateVehicle(VehicleDTO vehicle);
        Task UpdatePartVehicle(int id, string columnName, string columnValue);
        Task DeleteVehicle(int id);
        Task<int> GetVehicleIdByRegistration(string registration);
        Task<VehicleDTO> GetVehicleById(int id);
        Task<VehicleDTO> GetVehicleByRegistration(string registration);
        Task<int> CheckVehicleCorrectness(int idVehicle);
        Task<List<VehicleRegistrationTableViewDTO>> CheckVehicleValueDate(int idMine);
        Task InsertPicturesPath(string newPath, int idVehicle);
        Task RegistrateVehicle(int idVehicle, string dateTo);
        Task<List<VehicleTableViewDTO>> GetVehiclesByParameters(int idMine, int idCategory, int idSubcategory, int idOwner, int idState);
    }
}
