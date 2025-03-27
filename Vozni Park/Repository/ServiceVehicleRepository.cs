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
using Vozni_Park.View;

namespace Vozni_Park.Repository
{
    public class ServiceVehicleRepository: IServiceVehicleRepository
    {
        private readonly SqliteConnection _context;

        public ServiceVehicleRepository()
        {
            _context = AppDbContext.GetInstance();
        }
        public async Task<List<ServiceVehicleTableViewDTO>> GetAllRequestsForVehicleAsync(int id)
        {
            List<ServiceVehicleTableViewDTO> list = new List<ServiceVehicleTableViewDTO>();
            string query = "Select ServisVozila.id, ServisVozila.Datum, ServisVozila.Kilometraza, VrstaServisa.Naziv, Serviser.Naziv, ServisVozila.Opis, ServisVozila.Cena from (ServisVozila join VrstaServisa on VrstaServisa.id = ServisVozila.IdVrsteServisa) join Serviser on Serviser.Id = ServisVozila.IdServisera where ServisVozila.IdVozila = " + id;
            SqliteCommand command = new SqliteCommand(query, _context);
            var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                DateTime dateTo;
                if (DateTime.TryParseExact(reader.GetString(1), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTo))
                {
                    string registrationDuration = dateTo.ToString("dd/MM/yyyy");
                    if (!reader.IsDBNull(6))
                    {
                        list.Add(new ServiceVehicleTableViewDTO(reader.GetInt32(0), registrationDuration, reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetFloat(6)));
                    }
                    else
                    {
                        list.Add(new ServiceVehicleTableViewDTO(reader.GetInt32(0), registrationDuration, reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), 0));
                    }
                }
            }
            return list;
        }

        public async Task DeleteServiceVehicleAsync(int id)
        {
            string query = "Delete from servisVozila where id = " + id;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }

        public async Task DeleteAllConnectedWithServiceVehicleAsync(int id)
        {
            string query = "Delete from SlikeRacuna where idServisaVozila = " + id;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }

        public async Task<int> FindIdRequestForServiceIdAsync(int id)
        {
            string query = "Select idZahtevaZaServisom from servisVozila where id = " + id;
            SqliteCommand command = new SqliteCommand(query, _context);
            var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return reader.GetInt32(0);
            }
            return -1;
        }

        public async Task UpdateStatusOfRequestAsync(int idRequest)
        {
            string query = "Update ZahtevZaServisom set DaLiJeIspunjen = -1 where id = " + idRequest;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }
       

        public async Task<int> GetServiceRequestIdForServiceIdAsync(int id)
        {
            int IdServiceRequest = -1;
            string query = "select idZahtevaZaServisom from ServisVozila where id = @id";
            SqliteCommand command = new SqliteCommand(query, _context);
            command.Parameters.Add(new SqliteParameter("@id", id));
            var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                IdServiceRequest =  reader.GetInt32(0);
            }
            return IdServiceRequest;
        }
    }
}
