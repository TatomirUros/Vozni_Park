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
    public class ServiceTypeRepository:IServiceTypeRepository
    {
        private readonly SqliteConnection _context;
        public ServiceTypeRepository()
        {
            _context = AppDbContext.GetInstance();
        }
      
        public async Task<int> GetServiceTypeIdByNameAsync(string name)
        {
            int id = -1;
            string query = "Select id from vrstaServisa where naziv LIKE '%" + name + "%'";
            SqliteCommand command = new SqliteCommand(query, _context);
            var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                id = reader.GetInt32(0);

            }
            return id;
        }

        public async Task<List<ServiceTypeDTO>> GetAllServiceTypesAsync()
        {
            List<ServiceTypeDTO> names = new List<ServiceTypeDTO>();
            string query = "Select id, naziv from vrstaServisa";
            SqliteCommand command = new SqliteCommand(query, _context);
            var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                names.Add(new ServiceTypeDTO(reader.GetInt32(0), reader.GetString(1)));
            }
            return names;
        }

        public async Task InsertServiceTypeAsync(string name)
        {
            string query = "Insert into vrstaServisa (naziv) values ('" + name + "')";
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }
        public async Task UpdateServiceTypeAsync(int id, string name)
        {
            string query = "Update vrstaServisa set naziv = '" + name + "' where id = " + id;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }
        public async Task DeleteServiceTypeAsync(int id)
        {
            string query = "Delete from vrstaServisa where id = " + id;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }
        public async Task DeleteAllConnectedWithServiceTypeAsync(int id)
        {
            string query = "Delete from ServisVozila where idVrsteServisa = " + id;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();

            string query2 = "Delete from ZahtevZaServisom where idVrsteServisa = " + id;
            SqliteCommand command2 = new SqliteCommand(query2, _context);
            await command2.ExecuteNonQueryAsync();
        }
    }
}
