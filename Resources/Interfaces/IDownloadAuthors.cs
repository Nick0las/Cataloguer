﻿using Cataloguer.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Cataloguer.Resources.Interfaces
{
    internal interface IDownloadAuthors
    {
        internal static void ShowAuthors(ObservableCollection<BookAuthor> authors)
        {
            //строка запроса на выборку всех авторов из БД
            string sqlQuery = "SELECT * FROM BookAuthor ORDER BY SurnameAuthor ASC";

            ConnectionDB connection = new ();
            connection.OpenConnection();
            SqliteCommand cmdSelectAllBooks = new SqliteCommand(sqlQuery, connection.GetConnection());
            SqliteDataReader sqliteDataReader = cmdSelectAllBooks.ExecuteReader();

            while (sqliteDataReader.Read())
            {
                BookAuthor author = new ();
                author.Id = sqliteDataReader.GetInt32(0);
                author.Surname = sqliteDataReader.GetString(1);
                author.Name = sqliteDataReader.GetString(2);
                author.MidleName = sqliteDataReader.GetString(3);
                authors.Add (author);
            }
            sqliteDataReader.Close();
            connection.CloseConnection();
        }
        
    }
}
