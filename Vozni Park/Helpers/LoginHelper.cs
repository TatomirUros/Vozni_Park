using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.Context;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Vozni_Park.Helpers
{
    public class LoginHelper
    {
        private readonly SqliteConnection _context;

        public LoginHelper()
        {
            _context = AppDbContext.GetInstance();
        }

        private string HashStringSHA256(string input)
        {
            SHA256 sha256 = SHA256.Create();
            
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha256.ComputeHash(inputBytes);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                builder.Append(hashBytes[i].ToString("x2"));
            }

            return builder.ToString();
            
        }
        public async Task<int> CheckForExistence(string userName, string password)
        {
            string hashPassword = HashStringSHA256(password);
            string query = "select id from Korisnik where korisnickoIme=@userName and sifra=@password";
            SqliteCommand command = new SqliteCommand(query, _context);
            command.Parameters.Add(new SqliteParameter("@userName", userName));
            command.Parameters.Add(new SqliteParameter("@password", hashPassword));

            var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return reader.GetInt32(0);
            }
            return -1;

        }

        public async Task ChangePassword(int id, string newPassword)
        {
            string hashPassword = HashStringSHA256(newPassword);
            string query = "update Korisnik set sifra=@newPassword where id = @id";
            SqliteCommand command = new SqliteCommand(query, _context);
            command.Parameters.Add(new SqliteParameter("@id", id));
            command.Parameters.Add(new SqliteParameter("@newPassword", hashPassword));
            await command.ExecuteNonQueryAsync();
          

        }
    }
}
