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
    public class RepairerRepository:IRepairerRepository
    {
        private readonly SqliteConnection _context;
        public RepairerRepository()
        {
            _context = AppDbContext.GetInstance();
        }

        public async Task<int> GetRepairerIdByNameAsync(string name)
        {
            int id = -1;
            string query = "Select id from Serviser where naziv LIKE '%" + name + "%'";
            SqliteCommand command = new SqliteCommand(query, _context);
            var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                id = reader.GetInt32(0);

            }
            return id;
        }

        public async Task<List<RepairerDTO>> GetAllRepairersAsync()
        {
            List<RepairerDTO> names = new List<RepairerDTO>();
            string query = "Select id, naziv from serviser";
            SqliteCommand command = new SqliteCommand(query, _context);
            var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                names.Add(new RepairerDTO(reader.GetInt32(0), reader.GetString(1)));
            }
            return names;
        }

        public async Task InsertRepairerAsync(string name)
        {
            string query = "Insert into serviser (naziv) values ('" + name + "')";
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }
        public async Task UpdateRepairerAsync(int id, string name)
        {
            string query = "Update serviser set naziv = '" + name + "' where id = " + id;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }
        public async Task DeleteRepairerAsync(int id)
        {
            string query = "Delete from serviser where id = " + id;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }
        public async Task DeleteAllConnectedWithRepairerAsync(int id)
        {
            string query = "Delete from ServisVozila where idServisera = " + id;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }
    }
}
