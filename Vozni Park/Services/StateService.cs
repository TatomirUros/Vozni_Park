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
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;
        public StateService()
        {
            _stateRepository = new StateRepository();
        }
        public async Task<List<StateDTO>> GetAllStates()
        {
            return await _stateRepository.GetAllStatesAsync();
        }
    }
}
