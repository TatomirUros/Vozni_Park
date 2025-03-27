using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Vozni_Park.Context;
using Vozni_Park.DTOs;
using Vozni_Park.Repository.Interfaces;

namespace Vozni_Park.Repository
{
    public class ServiceRequestRepository:IServiceRequestRepository
    {
        private readonly SqliteConnection _context;

        public ServiceRequestRepository()
        {
            _context = AppDbContext.GetInstance();
        }
         public async Task InsertServiceRequestAsync(ServiceRequestDTO serviceRequest)
        {
            string query = "Insert into zahtevZaServisom (brojZahteva, opis, idVozila, IdVrsteServisa) values ('" + serviceRequest.Name + "' , '"+serviceRequest.Description+ "' , '"+serviceRequest.IdVehicle+ "' , '"+serviceRequest.IdServiceTpe+"')";
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }
        public async Task DeleteServiceRequestAsync(int id)
        {
            string query = "Delete from zahtevZaServisom where id = " + id;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }
        public async Task DeleteAllConnectedWithServiceRequestAsync(int id)
        {
            string query = "Delete from SlikeZahteva where idZahteva = " + id;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command .ExecuteNonQueryAsync();
        }
        public async Task<List<ServiceRequestTableViewDTO>> GetAllRequestsForVehicleAsync(int id)
        {
            List<ServiceRequestTableViewDTO> list = new List<ServiceRequestTableViewDTO>();
            string query = "Select ZahtevZaServisom.id, ZahtevZaServisom.BrojZahteva, VrstaServisa.naziv from ZahtevZaServisom join VrstaServisa on VrstaServisa.id = ZahtevZaServisom.idVrsteServisa where ZahtevZaServisom.idVozila = " + id + " and DaLiJeIspunjen = -1";
            SqliteCommand command = new SqliteCommand(query, _context);
            var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new ServiceRequestTableViewDTO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
            }
            return list;
        }

        public async Task<ServiceRequestShowDetailsDTO> GetRequestForRequestIdAsync(int id)
        {
            ServiceRequestShowDetailsDTO result = null;
            string query = "Select id, BrojZahteva, Opis from ZahtevZaServisom where id = @id";
            SqliteCommand command = new SqliteCommand(query, _context);
            command.Parameters.Add(new SqliteParameter("@id", id));
            var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                result = new ServiceRequestShowDetailsDTO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
            }
            return result;
        }

        public async Task InsertPictureAsync(string newPath, int id)
        {
            string query = "update zahtevZaServisom set putanjaDoSlike = '" + newPath + "' where id = " + id;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();

        }

        public async Task<int> GetVehicleIdForRequestIdAsync(int id)
        {
            string query = "Select idVozila from ZahtevZaServisom where id = " + id;
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
