﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.DTOs;

namespace Vozni_Park.Services.Interfaces
{
    public interface IRegistrationPlatesService
    {
        Task<List<RegistrationPlatesDTO>> GetAllRegistrationPlatesById(int vehicleId);
        Task DeleteRegistrationPlates(int id);
    }
}
