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
    internal class MineRepository : IMineRepository
    {
        private readonly SqliteConnection _context;
        public MineRepository()
        {
            _context = AppDbContext.GetInstance();
        }

        public async Task<List<MineDTO>> GetAllMinesAsync()
        {
            List<MineDTO> names = new List<MineDTO>();
            string query = "Select id, naziv from rudnik";
            SqliteCommand command = new SqliteCommand(query, _context);
            var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                names.Add(new MineDTO(reader.GetInt32(0), reader.GetString(1)));
            }
            return names;
        }

        public async Task InsertMineAsync(string name)
        {
            string query = "Insert into rudnik (naziv) values ('" + name + "')";
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }
        public async Task UpdateMineAsync(int id, string name)
        {
            string query = "Update rudnik set naziv = '" + name + "' where id = " + id;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }
        public async Task DeleteMineAsync(int id)
        {
            string query = "Delete from rudnik where id = " + id;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }

        public async Task<List<int>> GetAllVehicleForMineAsync(int id)
        {
            List<int> idVehicles = new List<int>();
            string query = "Select id from Vozilo where idRudnika = " + id;
            SqliteCommand command = new SqliteCommand(query, _context);
            var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                idVehicles.Add(reader.GetInt32(0));
            }
            return idVehicles;
        }
    }
}
