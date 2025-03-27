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
    public class OwnerRepository:IOwnerRepository
    {
        private readonly SqliteConnection _context;
        public OwnerRepository()
        {
            _context = AppDbContext.GetInstance();
        }

        public async Task<List<OwnerDTO>> GetAllOwnersAsync()
        {
            List<OwnerDTO> names = new List<OwnerDTO>();
            string query = "Select id, naziv from vlasnik";
            SqliteCommand command = new SqliteCommand(query, _context);
            var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                names.Add(new OwnerDTO(reader.GetInt32(0), reader.GetString(1)));
            }
            return names;
        }

        public async Task<List<int>> GetAllVehicleForOwnerAsync(int id)
        {
            List<int> idVehicles = new List<int>();
            string query = "Select id from Vozilo where idVlasnika = " + id;
            SqliteCommand command = new SqliteCommand(query, _context);
            var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                idVehicles.Add(reader.GetInt32(0));
            }
            return idVehicles;
        }

        public async Task InsertOwnerAsync(string name)
        {
            string query = "Insert into vlasnik (naziv) values ('" + name + "')";
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }
        public async Task UpdateOwnerAsync(int id, string name)
        {
            string query = "Update vlasnik set naziv = '" + name + "' where id = " + id;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }
        public async Task DeleteOwnerAsync(int id)
        {
            string query = "Delete from vlasnik where id = " + id;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }
    }
}
