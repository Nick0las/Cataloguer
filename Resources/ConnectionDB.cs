using Microsoft.Data.Sqlite;
using System;
using System.IO;

namespace Cataloguer.Resources
{
    internal class ConnectionDB
    {
        /// <summary>Конструктор подключения к БД</summary>
        private readonly SqliteConnection connection = new ("Data Source=" + @"..\\..\\..\\Data\\DB\\BookСatalog.db; Mode=ReadWrite");

        /// <summary> Метод подключения к БД</summary>
        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        /// <summary> Метод закрытия подключения к БД</summary>
        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public SqliteConnection GetConnection()
        {
            return connection;
        }
    }
}
