using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.Repository.Interfaces;
using Vozni_Park.Repository;
using Vozni_Park.Services.Interfaces;
using Vozni_Park.DTOs;
using Vozni_Park.View;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;
using static System.Windows.Forms.AxHost;
using System.Windows.Forms.Design.Behavior;

namespace Vozni_Park.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        public VehicleService()
        {
            _vehicleRepository = new VehicleRepository();
        }

        public async Task DeleteVehicle(int id)
        {
            await _vehicleRepository.DeleteAllConnectedWithVehicleAsync(id);
            await _vehicleRepository.DeleteVehicleAsync(id);
        }


        public async Task InsertVehicle(VehicleDTO vehicle)
        {
            await _vehicleRepository.InsertVehicleAsync(vehicle);

            int id = await GetVehicleIdByRegistration(vehicle.Registration);
            await _vehicleRepository.InsertRegistration(new RegistrationVehicleDTO(0, vehicle.Registration, id));

        }

        public async Task UpdatePartVehicle(int id, string columnName, string columnValue)
        {
            await _vehicleRepository.UpdatePartVehicleAsync(id, columnName, columnValue);

            if(columnName.Equals("registracija"))
                if (!(await _vehicleRepository.FindRegistrationForIdAndRegistration(id, columnValue)))
                    await _vehicleRepository.InsertRegistration(new RegistrationVehicleDTO(0, columnValue, id));
            
        }

        public async Task UpdateVehicle(VehicleDTO vehicle)
        {
            await _vehicleRepository.UpdateVehicleAsync(vehicle);

            if (!(await _vehicleRepository.FindRegistrationForIdAndRegistration(vehicle.Id, vehicle.Registration)))
                await _vehicleRepository.InsertRegistration(new RegistrationVehicleDTO(0, vehicle.Registration, vehicle.Id));
        }

        public async Task<VehicleDTO> GetVehicleById(int id)
        {
            return await _vehicleRepository.GetVehicleByIdAsync(id);
        }
        public async Task<int> GetVehicleIdByRegistration(string registration)
        {
            return await _vehicleRepository.GetVehicleIdByRegistrationAsync(registration);
        }
        public async Task<VehicleDTO> GetVehicleByRegistration(string registration)
        {
            return await _vehicleRepository.GetVehicleByRegistrationAsync(registration);
        }
        public async Task<int> CheckVehicleCorrectness(int idVehicle)
        {
            return await _vehicleRepository.CheckVehicleCorrectnessAsync(idVehicle);
        }
        public async Task<List<VehicleRegistrationTableViewDTO>> CheckVehicleValueDate(int idMine)
        {
            return await _vehicleRepository.CheckVehicleValueDateAsync(idMine);
        }

        public async Task InsertPicturesPath(string newPath, int idVehicle)
        {
            await _vehicleRepository.InsertPicturesPathAsync(newPath, idVehicle);
        }

        public async Task RegistrateVehicle(int idVehicle, string dateTo)
        {
            DateTime dateToChange = DateTime.ParseExact(dateTo, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            dateToChange = dateToChange.AddYears(1);
            string changedDate = dateToChange.ToString("yyyy-MM-dd");
            /* zamenjeno zbog starijeg racunara ne zna za dateOnly
            DateOnly dateToChange = DateOnly.ParseExact(dateTo, "dd/MM/yyyy");
            dateToChange = dateToChange.AddYears(1);
            string changedDate = dateToChange.ToString("yyyy-MM-dd");*/
            await _vehicleRepository.RegistrateVehicleAsync(idVehicle, changedDate);
        }
        public async Task<List<VehicleTableViewDTO>> GetVehiclesByParameters(int idMine, int idCategory, int idSubcategory, int idOwner, int idState)
        {
            return await _vehicleRepository.GetVehiclesByParametersAsync(idMine, idCategory, idSubcategory, idOwner, idState);
        }
    }
}
