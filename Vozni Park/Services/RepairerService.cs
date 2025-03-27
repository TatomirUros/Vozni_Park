using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.DTOs;
using Vozni_Park.Repository.Interfaces;
using Vozni_Park.Repository;
using System.ComponentModel.Design;
using Vozni_Park.Services.Interfaces;

namespace Vozni_Park.Services
{
    public class RepairerService : IRepairerService
    {
        private readonly IRepairerRepository _repairerRepository;
        public RepairerService()
        {
            _repairerRepository = new RepairerRepository();
        }
        public async Task<List<RepairerDTO>> GetAllRepairers()
        {
            return await _repairerRepository.GetAllRepairersAsync();
        }

        public async Task<int> GetRepairerIdByName(string name)
        {
            return await _repairerRepository.GetRepairerIdByNameAsync(name);
        }
        public async Task InsertRepairer(string name)
        {
            await _repairerRepository.InsertRepairerAsync(name);
        }
        public async Task UpdateRepairer(int id, string name)
        {
            await _repairerRepository.UpdateRepairerAsync(id, name);
        }
        public async Task DeleteRepairer(int id)
        {
            await _repairerRepository.DeleteAllConnectedWithRepairerAsync(id);
            await _repairerRepository.DeleteRepairerAsync(id);
        }

    }
}
