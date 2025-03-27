using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.Context;
using Vozni_Park.DTOs;
using Vozni_Park.Repository.Interfaces;
using Vozni_Park.View;

namespace Vozni_Park.Repository
{
    public class ExecuteRequestRepository : IExecuteRequestRepository
    {
        private readonly SqliteConnection _context;
        public ExecuteRequestRepository() 
        {
            _context = AppDbContext.GetInstance();
        }
        public async Task ExecuteRequestAsync(ExecuteRequestDTO executeRequest)
        {
            string query = "Insert into ServisVozila (opis, kilometraza, datum, idVozila, idVrsteServisa, idServisera, idZahtevaZaServisom, cena) values ('" + executeRequest.Description + "' ,'" + executeRequest.Kilometers + "' ,'" + executeRequest.Date.ToString("yyyy-MM-dd") + "' ,'" + executeRequest.IdVehicle + "' ,'" + executeRequest.IdServiceTpe + "' ,'" + executeRequest.IdRepairer + "' ,'" + executeRequest.IdRequest + "' ,'" + executeRequest.Price + "')";
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();

            string query2 = "Update ZahtevZaServisom set DaLiJeIspunjen = 1 where id = "+executeRequest.IdRequest;
            SqliteCommand command2 = new SqliteCommand(query2, _context);
            await command2.ExecuteNonQueryAsync();
        }
        public async Task UpdateExecutedRequestAsync(ExecuteRequestDTO executeRequest)
        {
            string query = "Update ServisVozila set opis = '" + executeRequest.Description + "', kilometraza = '" + executeRequest.Kilometers + "', datum = '" + executeRequest.Date.ToString("yyyy-MM-dd") + "', idVozila = '" + executeRequest.IdVehicle + "', idVrsteServisa = '" + executeRequest.IdServiceTpe + "', idServisera = '" + executeRequest.IdRepairer + "', cena = '" + executeRequest.Price + "' where id = " + executeRequest.Id;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }

        public async Task<int> GetRequestIdByServiceVehicleIdAsync(int serviceVehicleId)
        {
            string query = "Select idZahtevaZaServisom from ServisVozila where id= " + serviceVehicleId;
            SqliteCommand command = new SqliteCommand(query, _context);
            var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return reader.GetInt32(0);

            }
            return -1;
        }

        public async Task InsertPictureAsync(string newPath, int id)
        {
            string query = "update zahtevZaServisom set putanjaDoSlike = '" + newPath + "' where id = " + id;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();

        }

        public async Task<int> GetMaxIdExecuteAsync()
        {
            string query = "Select MAX(id) from servisVozila";
            SqliteCommand command = new SqliteCommand(query, _context);
            var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return reader.GetInt32(0);
                
            }
            return -1;
        }
    }
}
