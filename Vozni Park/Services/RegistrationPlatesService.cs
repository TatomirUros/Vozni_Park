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
    public class RegistrationPlatesService : IRegistrationPlatesService
    {
        private readonly IRegistrationPlatesRepository _registrationPlatesRepository;
        public RegistrationPlatesService() 
        {
            _registrationPlatesRepository = new RegistrationPlatesRepository();
        }
        public async Task DeleteRegistrationPlates(int id)
        {
            await _registrationPlatesRepository.DeleteRegistrationPlatesAsync(id);
        }

        public async Task<List<RegistrationPlatesDTO>> GetAllRegistrationPlatesById(int vehicleId)
        {
           return await _registrationPlatesRepository.GetAllRegistrationPlatesByIdAsync(vehicleId);
        }
    }
}
