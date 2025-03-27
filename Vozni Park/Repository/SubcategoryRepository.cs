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
    public class SubcategoryRepository : ISubcategoryRepository
    {
        private readonly SqliteConnection _context;
        public SubcategoryRepository()
        {
            _context = AppDbContext.GetInstance();
        }

        public async Task<string> GetSubcategoryNameByIdAsync(int id)
        {
            string name = "";
            string query = "Select naziv from potkategorija where id = " + id;
            SqliteCommand command = new SqliteCommand(query, _context);
            var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                name = reader.GetString(0);

            }
            return name;
        }
        public async Task<int> GetCategoryIdBySubcategoryIdAsync(int subcategotyId)
        {
            int categoryId = -1;
            string query = "Select idKategorije from potkategorija where id = " + subcategotyId;
            SqliteCommand command = new SqliteCommand(query, _context);
            var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                categoryId = int.Parse(reader.GetString(0));

            }
            return categoryId;
        }

        public async Task<List<SubcategoryDTO>> GetAllSubcategoriesAsync()
        {
            List<SubcategoryDTO> names = new List<SubcategoryDTO>();
            string query = "Select id, naziv from potkategorija";
            SqliteCommand command = new SqliteCommand(query, _context);
            var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                names.Add(new SubcategoryDTO(reader.GetInt32(0), reader.GetString(1)));
            }
            return names;
        }

        public async Task<List<SubcategoryDTO>> GetAllSubcategoriesByCategoryIdAsync(int categoryId)
        {
            List<SubcategoryDTO> names = new List<SubcategoryDTO>();
            string query = "Select id, naziv from potkategorija where idKategorije = " + categoryId;
            SqliteCommand command = new SqliteCommand(query, _context);
            var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                names.Add(new SubcategoryDTO(reader.GetInt32(0), reader.GetString(1)));
            }
            return names;
        }

        public async Task InsertSubcategoryAsync(string name, int categoryId)
        {
            string query = "Insert into potkategorija (naziv, idKategorije) values ('" + name + "', '" + categoryId + "')";
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }
        public async Task UpdateSubcategoryAsync(int id, string name, int categoryId)
        {
            string query = "Update potkategorija set naziv = '" + name + "', idKategorije = '" + categoryId + "' where id = " + id;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }
        public async Task DeleteSubcategoryAsync(int id)
        {
            string query = "Delete from potkategorija where id = " + id;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }

        public async Task<List<int>> GetAllVehicleForSubcategoryAsync(int id)
        {
            List<int> idVehicles = new List<int>();
            string query = "Select id from Vozilo where idPotkategorije = " + id;
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
