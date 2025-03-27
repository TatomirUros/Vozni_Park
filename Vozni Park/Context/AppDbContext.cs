using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vozni_Park.Context
{
    public class AppDbContext
    {
        private static SqliteConnection _connection;
        private static readonly object _lock = new object();

        private AppDbContext()
        {}

        public static SqliteConnection GetInstance()
        {
            lock (_lock)
            {
                if (_connection == null)
                {
                    string currentDirectory = Directory.GetCurrentDirectory() + "\\JPPEU.db";
                    //string currentDirectory = "../../../JPPEU.db";

                    string connectionString = @"Data Source=" + currentDirectory;
                    _connection = new SqliteConnection(connectionString);
                    _connection.Open();
                }

                if (_connection.State != System.Data.ConnectionState.Open)
                {
                    _connection.Open();
                }

                return _connection;
            }
        }
        public static void CloseConnection()
        {
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}

