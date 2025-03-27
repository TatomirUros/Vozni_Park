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
    internal class RegistrationPlatesRepository : IRegistrationPlatesRepository
    {
        private readonly SqliteConnection _context;
        public RegistrationPlatesRepository()
        {
            _context = AppDbContext.GetInstance();
        }
        public async Task DeleteRegistrationPlatesAsync(int id)
        {
            string query = "Delete from registracijeVozila where id = " + id;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }

        public async Task<List<RegistrationPlatesDTO>> GetAllRegistrationPlatesByIdAsync(int vehicleId)
        {
            List<RegistrationPlatesDTO> registrations = new List<RegistrationPlatesDTO>();
            string query = "Select id, registracija, idVozila from registracijeVozila where idVozila = " + vehicleId;
            SqliteCommand command = new SqliteCommand(query, _context);
            var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                registrations.Add(new RegistrationPlatesDTO(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
            }
            return registrations;
        }
    }
}
