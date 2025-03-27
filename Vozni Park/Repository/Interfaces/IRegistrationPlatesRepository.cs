using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.DTOs;

namespace Vozni_Park.Repository.Interfaces
{
    public interface IRegistrationPlatesRepository
    {
        Task<List<RegistrationPlatesDTO>> GetAllRegistrationPlatesByIdAsync(int vehicleId);
        Task DeleteRegistrationPlatesAsync(int id);
    }
}
