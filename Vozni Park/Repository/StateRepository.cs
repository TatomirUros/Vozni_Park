using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.Context;
using Vozni_Park.DTOs;
using Vozni_Park.Repository.Interfaces;

namespace Vozni_Park.Repository
{
    internal class StateRepository : IStateRepository
    {
        private readonly SqliteConnection _context;
        public StateRepository()
        {
            _context = AppDbContext.GetInstance();
        }
        public async Task<List<StateDTO>> GetAllStatesAsync()
        {
            List<StateDTO> names = new List<StateDTO>();
            string query = "Select id, naziv from stanjeVozila";
            SqliteCommand command = new SqliteCommand(query, _context);
            var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                names.Add(new StateDTO(reader.GetInt32(0), reader.GetString(1)));
            }
            return names;
        }
    }
}
