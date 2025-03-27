using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.Context;
using Vozni_Park.DTOs;
using Vozni_Park.Repository.Interfaces;

namespace Vozni_Park.Repository
{
    internal class TagRepository : ITagRepository
    {
        private readonly SqliteConnection _context;
        public TagRepository()
        {
            _context = AppDbContext.GetInstance();
        }

        public async Task<TagDTO> GetTagIdByRegistrationAsync(string registration)
        {
            TagDTO tag = null;
            string query = "Select id, registracija, serijskiBroj from tag where registracija LIKE  '%" + registration + "%'";
            SqliteCommand command = new SqliteCommand(query, _context);
            var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                tag = new TagDTO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
            }
            return tag;
        }

        public async Task<List<TagTableViewDTO>> GetAllTagsForTableViewAsync()
        {
            List<TagTableViewDTO> tags = new List<TagTableViewDTO>();
            string query = "Select DISTINCT tag.id, registracija, serijskiBroj, max(datum) as datum from tag left join punjenjeTaga on punjenjeTaga.IdTaga = Tag.Id GROUP BY tag.id, tag.registracija, tag.serijskiBroj;";
            SqliteCommand command = new SqliteCommand(query, _context);
            var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {

                if (reader.IsDBNull(3))
                    tags.Add(new TagTableViewDTO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), "Nema informacija"));
                else
                {
                    DateTime dateTo;
                    if (DateTime.TryParseExact(reader.GetString(3), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTo))
                    {
                        string registrationDuration = dateTo.ToString("dd/MM/yyyy");
                        tags.Add(new TagTableViewDTO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), registrationDuration));
                    }
                }
            }
            return tags;
        }

        public async Task InsertTagAsync(TagDTO tag)
        {
            string query = "Insert into tag (Registracija, SerijskiBroj) values ('" + tag.Registration + "' ,'" + tag.SerialNumber + "')";
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }
        public async Task UpdateTagAsync(TagDTO tag)
        {
            string query = "Update tag set registracija = '" + tag.Registration + "' , serijskiBroj = '" + tag.SerialNumber + "' where id = " + tag.Id;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }
        public async Task DeleteTagAsync(int id)
        {
            string query = "Delete from tag where id = " + id;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }
        public async Task DeleteAllConnectedWithTagAsync(int id)
        {
            string query = "Delete from PunjenjeTaga where idTaga = " + id;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }
    }
}
