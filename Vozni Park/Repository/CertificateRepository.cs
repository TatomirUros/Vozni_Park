using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vozni_Park.Context;
using Vozni_Park.Repository.Interfaces;
using Vozni_Park.View;

namespace Vozni_Park.Repository
{
    public class CertificateRepository : ICertificateRepository
    {

        private readonly SqliteConnection _context;

        public CertificateRepository()
        {
            _context = AppDbContext.GetInstance();
        }

        public async Task UpdatePictureAsync(string path, int vehicleId)
        {
        
            string query = "update vozilo set saobracajna = '" + path + "' where id = " + vehicleId;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();

        }
    }
}

