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
    internal class CategoryRepository : ICategoryRepository
    {
        private readonly SqliteConnection _context;
        public CategoryRepository()
        {
            _context = AppDbContext.GetInstance();
        }

        public async Task<string> GetCategoryNameByIdAsync(int id)
        {
            string name = "";
            string query = "Select naziv from kategorija where id = " + id;
            SqliteCommand command = new SqliteCommand(query, _context);
            var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                name = reader.GetString(0);

            }
            return name;
        }

        public async Task<List<CategoryDTO>> GetAllCategoriesAsync()
        {
            List<CategoryDTO> names = new List<CategoryDTO>();
            string query = "Select id, naziv from kategorija";
            SqliteCommand command = new SqliteCommand(query, _context);
            var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                names.Add(new CategoryDTO(reader.GetInt32(0), reader.GetString(1)));
            }
            return names;
        }

        public async Task InsertCategoryAsync(string name)
        {
            string query = "Insert into kategorija (naziv) values ('" + name + "')";
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }
        public async Task UpdateCategoryAsync(int id, string name)
        {
            string query = "Update kategorija set naziv = '" + name + "' where id = " + id;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }
        public async Task DeleteCategoryAsync(int id)
        {
            string query = "Delete from kategorija where id = " + id;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }
    }
}
