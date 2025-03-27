using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Vozni_Park.Context;
using Vozni_Park.DTOs;
using Vozni_Park.Repository.Interfaces;
using Vozni_Park.View;


namespace Vozni_Park.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly SqliteConnection _context;
        public VehicleRepository()
        {
            _context = AppDbContext.GetInstance();
        }

        public async Task InsertVehicleAsync(VehicleDTO vehicle)
        {
            string dateTo = vehicle.DateTo.ToString("yyyy-MM-dd");

            string query = "Insert into vozilo (marka, model, kilometraza, idVlasnika, idRudnika, idKategorije, idPotkategorije, registracija, datumDoKada, idStanja) values ('" + vehicle.Brand + "', '" + vehicle.Model + "', '" + vehicle.Kilometers + "', " + vehicle.IdOwner + ", " + vehicle.IdMine + ", " + vehicle.IdCategory + ", " + vehicle.IdSubcategory + " , '" + vehicle.Registration + "', '" + dateTo + "', '" + vehicle.IdState + "')";
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }
        public async Task UpdateVehicleAsync(VehicleDTO vehicle)
        {
            string dateTo = vehicle.DateTo.ToString("yyyy-MM-dd");
            string query = "Update vozilo set marka = '" + vehicle.Brand + "', model = '" + vehicle.Model + "', kilometraza = '" + vehicle.Kilometers + "', idVlasnika = '" + vehicle.IdOwner + "', idRudnika = '" + vehicle.IdMine + "', idKategorije = '" + vehicle.IdCategory + "', idPotkategorije = '" + vehicle.IdSubcategory + "', registracija = '" + vehicle.Registration + "', datumDoKada = '" + dateTo + "', idStanja = '" + vehicle.IdState + "', DimenzijeGuma = '" + vehicle.TireDimension + "'  where id = " + vehicle.Id;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }
        public async Task DeleteVehicleAsync(int id)
        {
            string query = "Delete from vozilo where id = " + id;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }
        public async Task DeleteAllConnectedWithVehicleAsync(int id)
        {
            string query = "Delete from RegistracijeVozila where idVozila = " + id;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();

            string query2 = "Delete from ServisVozila where idVozila = " + id;
            SqliteCommand command2 = new SqliteCommand(query2, _context);
            await command2.ExecuteNonQueryAsync();

            string query3 = "Delete from ZahtevZaServisom where idVozila = " + id;
            SqliteCommand command3 = new SqliteCommand(query3, _context);
            await command3.ExecuteNonQueryAsync();
        }

        public async Task UpdatePartVehicleAsync(int id, string columnName, string columnValue)
        {
            string query = "Update vozilo set " + columnName + " = '" + columnValue + "' where id = " + id;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }

        public async Task<VehicleDTO> GetVehicleByIdAsync(int id)
        {
            VehicleDTO vehicle = null;
            string query = "Select id, marka, model, kilometraza, idVlasnika, IdRudnika, registracija, datumDoKada, idStanja from vozilo where id = '" + id + "'";
            SqliteCommand command = new SqliteCommand(query, _context);
            var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                vehicle = new VehicleDTO();
                vehicle.Id = int.Parse(reader.GetString(0));
                vehicle.Brand = reader.GetString(1);
                vehicle.Model = reader.GetString(2);
                vehicle.Kilometers = reader.GetString(3);
                vehicle.IdOwner = int.Parse(reader.GetString(4));
                vehicle.IdMine = int.Parse(reader.GetString(5));
                vehicle.Registration = reader.GetString(6);
                vehicle.DateTo = DateOnly.Parse(reader.GetString(7));
                vehicle.IdState = int.Parse(reader.GetString(8));
            }

            return vehicle;
        }

        public async Task<int> GetVehicleIdByRegistrationAsync(string registration)
        {
            int id = -1;
            string query = "Select id from vozilo where registracija Like '%" + registration + "%'";
            SqliteCommand command = new SqliteCommand(query, _context);
            var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                id = int.Parse(reader.GetString(0));

            }
            return id;
        }
        public async Task<VehicleDTO> GetVehicleByRegistrationAsync(string registration)
        {
            VehicleDTO vehicle = null;
            string query = "Select id, marka, model, kilometraza, idVlasnika, IdRudnika, idKategorije, idPotkategorije, registracija, datumDoKada, idStanja, dimenzijeGuma from vozilo where registracija Like '%" + registration + "%'";
            SqliteCommand command = new SqliteCommand(query, _context);
            var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                vehicle = new VehicleDTO();
                vehicle.Id = int.Parse(reader.GetString(0));
                vehicle.Brand = reader.GetString(1);
                vehicle.Model = reader.GetString(2);
                vehicle.Kilometers = reader.GetString(3);
                vehicle.IdOwner = int.Parse(reader.GetString(4));
                vehicle.IdMine = int.Parse(reader.GetString(5));
                vehicle.IdCategory = int.Parse(reader.GetString(6));
                vehicle.IdSubcategory = int.Parse(reader.GetString(7));
                vehicle.Registration = reader.GetString(8);
                vehicle.DateTo = DateOnly.Parse(reader.GetString(9));
                vehicle.IdState = int.Parse(reader.GetString(10));
                vehicle.TireDimension = reader.GetString(11);
            }

            return vehicle;
        }

        public async Task<bool> FindRegistrationForIdAndRegistration(int id, string registration)
        {
            string query = "Select id from RegistracijeVozila where idVozila = " + id + " and registracija = '" + registration + "'";
            SqliteCommand command = new SqliteCommand(query, _context);
            var reader = await command.ExecuteReaderAsync();

            return await reader.ReadAsync();
        }

        public async Task InsertRegistration(RegistrationVehicleDTO registrationVehicle)
        {
            string query = "Insert into registracijeVozila (registracija, idVozila) values ('" + registrationVehicle.Registration + "', '" + registrationVehicle.IdVehicle.ToString() + "')";
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }

        public async Task<int> CheckVehicleCorrectnessAsync(int idVehicle)
        {
            string query = "Select count(id) as brojZahteva from ZahtevZaServisom where DaLiJeIspunjen = -1 and idVozila = " + idVehicle;
            SqliteCommand command = new SqliteCommand(query, _context);
            var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
                return reader.GetInt32(0);

            return -1;
        }
        public async Task<List<VehicleRegistrationTableViewDTO>> CheckVehicleValueDateAsync(int idMine)
        {
            List<VehicleRegistrationTableViewDTO> vehicles = new List<VehicleRegistrationTableViewDTO>();

            // slucaj na pocetku prikazuje sve rudinke
            string query = "";
            DateTime date = DateTime.Now.AddMonths(1);
            string checkDate = date.ToString("yyyy-MM-dd");
            if (idMine == -1)
            {
                query = "Select vozilo.id, vozilo.marka, vozilo.model, Vlasnik.Naziv, Rudnik.Naziv, vozilo.registracija, vozilo.datumDoKada, StanjeVozila.Naziv from vozilo join StanjeVozila on StanjeVozila.id = vozilo.idStanja join Vlasnik on Vlasnik.Id = Vozilo.IdVlasnika JOIN Rudnik on Rudnik.Id = Vozilo.IdRudnika left join ZahtevZaServisom on vozilo.Id = ZahtevZaServisom.IdVozila WHERE ( DatumDoKada < @date and DatumDoKada > '2000-01-01' ) and StanjeVozila.Naziv != 'Otpis' GROUP by vozilo.id, marka, model, kilometraza, Vlasnik.Naziv, Rudnik.Naziv, registracija, datumDoKada ORDER BY vozilo.marka, vozilo. model, Vlasnik.Naziv";
            }
            else
            {
                query = "Select vozilo.id, vozilo.marka, vozilo.model, Vlasnik.Naziv, Rudnik.Naziv, vozilo.registracija, vozilo.datumDoKada, StanjeVozila.Naziv from vozilo join StanjeVozila on StanjeVozila.id = vozilo.idStanja join Vlasnik on Vlasnik.Id = Vozilo.IdVlasnika JOIN Rudnik on Rudnik.Id = Vozilo.IdRudnika left join ZahtevZaServisom on vozilo.Id = ZahtevZaServisom.IdVozila WHERE ( DatumDoKada < @date and DatumDoKada > '2000-01-01' ) and IdRudnika = @id and StanjeVozila.Naziv != 'Otpis' GROUP by vozilo.id, marka, model, kilometraza, Vlasnik.Naziv, Rudnik.Naziv, registracija, datumDoKada ORDER BY vozilo.marka, vozilo. model, Vlasnik.Naziv";
            }
            SqliteCommand command = new SqliteCommand(query, _context);
            command.Parameters.Add(new SqliteParameter("@id", idMine));
            command.Parameters.Add(new SqliteParameter("@date", checkDate));


            var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                DateTime dateTo;
                if (DateTime.TryParseExact(reader.GetString(6), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTo))
                {
                    string registrationDuration = dateTo.ToString("dd/MM/yyyy");
                    vehicles.Add(new VehicleRegistrationTableViewDTO(int.Parse(reader.GetString(0)), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), registrationDuration, reader.GetString(7)));
                }
            }
            return vehicles;
        }

        public async Task InsertPicturesPathAsync(string newPath, int idVehicle)
        {
            string query = "Update vozilo set PutanjaDoSlikaVozila = '" + newPath + "' where id = " + idVehicle;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }

        public async Task RegistrateVehicleAsync(int idVehicle, string dateTo)
        {
            string query = "Update vozilo set datumDoKada = '" + dateTo + "' where id = " + idVehicle;
            SqliteCommand command = new SqliteCommand(query, _context);
            await command.ExecuteNonQueryAsync();
        }

        public async Task<List<VehicleTableViewDTO>> GetVehiclesByParametersAsync(int idMine, int idCategory, int idSubcategory, int idOwner, int idState)
        {
            List<VehicleTableViewDTO> vehicles = new List<VehicleTableViewDTO>();

            // slucaj na pocetku prikazuje sve rudinke
            string queryBeforeWhere = "SELECT vozilo.id, vozilo.marka, vozilo.model, vozilo.kilometraza, Vlasnik.Naziv, Rudnik.Naziv, vozilo.registracija, vozilo.datumDoKada, StanjeVozila.Naziv, Kategorija.Naziv, Potkategorija.Naziv, vozilo.dimenzijeGuma FROM Vozilo JOIN StanjeVozila ON StanjeVozila.id = vozilo.idStanja JOIN Vlasnik ON Vlasnik.Id = Vozilo.IdVlasnika JOIN Rudnik ON Rudnik.Id = Vozilo.IdRudnika JOIN Kategorija ON Vozilo.IdKategorije = Kategorija.Id JOIN Potkategorija ON Vozilo.IdPotkategorije = Potkategorija.Id";
            string queryAfterWhere = " GROUP BY vozilo.id, marka, model, kilometraza, Vlasnik.Naziv, Rudnik.Naziv, registracija, datumDoKada ORDER BY vozilo.marka, vozilo. model, Vlasnik.Naziv";
            string queryWhere = " WHERE";
            int checkForAnd = 0;
            if (idMine != -1 )
            {
                queryWhere += " vozilo.idRudnika = @idMine";
                checkForAnd = 1;
            }
            if (idCategory != -1)
            {
                if (checkForAnd == 1)
                    queryWhere += " and";

                queryWhere += " vozilo.idKategorije= @idCategory";
                checkForAnd = 1;
            }
            if (idSubcategory != -1)
            {
                if (checkForAnd == 1)
                    queryWhere += " and";

                queryWhere += " vozilo.idPotkategorije = @idSubcategory";
                checkForAnd = 1;
            }
            if (idOwner!= -1)
            {
                if (checkForAnd == 1)
                    queryWhere += " and";

                queryWhere += " vozilo.idVlasnika = @idOwner";
                checkForAnd = 1;
            }
            if (idState!= -1)
            {
                if (checkForAnd == 1)
                    queryWhere += " and";

                queryWhere += " vozilo.idStanja = @idState";
                checkForAnd = 1;
            }
            string query = "";
            if (checkForAnd == 1)
                query = queryBeforeWhere + queryWhere + queryAfterWhere;
            else
                query = queryBeforeWhere + queryAfterWhere;
            SqliteCommand command = new SqliteCommand(query, _context);
            command.Parameters.Add(new SqliteParameter("@idMine", idMine));
            command.Parameters.Add(new SqliteParameter("@idCategory", idCategory));
            command.Parameters.Add(new SqliteParameter("@idSubcategory", idSubcategory));
            command.Parameters.Add(new SqliteParameter("@idOwner", idOwner));
            command.Parameters.Add(new SqliteParameter("@idState", idState));

            var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                DateOnly dateTo;
                DateOnly checkDate = new DateOnly(2000, 01, 01);

                if (DateOnly.TryParseExact(reader.GetString(7), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTo))
                {
                    string registrationDuration = dateTo.ToString("dd/MM/yyyy");
                    if (dateTo < checkDate)
                        registrationDuration = "Nije registoravano";

                    vehicles.Add(new VehicleTableViewDTO(int.Parse(reader.GetString(0)), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), registrationDuration, reader.GetString(8), reader.GetString(9), reader.GetString(10), reader.GetString(11)));
                }
            }
            return vehicles;
        }
    }
}
