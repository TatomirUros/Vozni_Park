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
    public class TagReplenishmentRepository : ITagReplenishmentRepository
    {
        private readonly SqliteConnection _context;
        public TagReplenishmentRepository()
        {
            _context = AppDbContext.GetInstance();
        }

        public async Task<List<TagReplenishmentTableViewDTO>> GetAllTagReplenishmentsForTableViewAsync(int idTag)
        {
            List<TagReplenishmentTableViewDTO> tagReplenishments = new List<TagReplenishmentTableViewDTO>();
            string query = "Select punjenjeTaga.id, datum, koliko from tag join punjenjeTaga on punjenjeTaga.IdTaga = Tag.Id where tag.id = " + idTag ;
            SqliteCommand command = new SqliteCommand(query, _context);
            var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                DateTime dateTo;
                if (DateTime.TryParseExact(reader.GetString(1), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTo))
                {
                    string registrationDuration = dateTo.ToString("dd/MM/yyyy");
                    tagReplenishments.Add(new TagReplenishmentTableViewDTO(reader.GetInt32(0), registrationDuration, float.Parse(reader.GetString(2))));
                }
            }
            return tagReplenishments;
        }

        public async Task InsertTagReplenishmentAsync(TagReplenishmentDTO tagReplenishment)
        {
            string query = "Insert into punjenjeTaga (datum, koliko, idTaga) values ('" + tagReplenishment.Date + "' ,'" + tagReplenishment.Amount + "' ,'" + tagReplenishment.IdTag + "')";
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }
        public async Task DeleteTagReplenishmentAsync(int id)
        {
            string query = "Delete from PunjenjeTaga where id = " + id;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }
    }
}
