using Cataloguer.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Cataloguer.Resources.Interfaces
{
    internal interface IDownloadAllBooks
    {
        /// <summary>
        /// получение информации о книгах, сохраненных в БД в ObservableCollection
        /// </summary>
        /// <param name="Books"></param>
        internal static void ShowBooks(ObservableCollection<Book> Books)
        {
            //запрос к БД на выборку из 2 таблиц(автор, книга) - возвращает ФИО_автора, название_книги, жанр_книги, год_издания
            string sqlQuery = "SELECT BookAuthor.SurnameAuthor, BookAuthor.NameAuthor, " +
                "BookAuthor.MidlenameAuthor, Books.BookTitle, Books.BookGenres, " +
                "Books.BookYearPublication, Books.Content " +
                "FROM Books " +
                "LEFT JOIN BookAuthor " +
                "ON Books.BookAuthorID = BookAuthor.IdAuthor;";

            ConnectionDB connection = new ConnectionDB();
            connection.OpenConnection();
            SqliteCommand cmdSelectAllBooks = new SqliteCommand(sqlQuery, connection.GetConnection());
            SqliteDataReader sqliteDataReader = cmdSelectAllBooks.ExecuteReader();

            while (sqliteDataReader.Read())
            {
                Book book = new();

                BookAuthor author = new();
                author.Surname = sqliteDataReader[0].ToString();
                author.Name = sqliteDataReader[1].ToString();
                author.MidleName = sqliteDataReader[2].ToString();
                book.Author = author;

                //string author;
                //author = sqliteDataReader[0].ToString();
                //author = author + " " + sqliteDataReader[1].ToString();
                //author = author + " " + sqliteDataReader[2].ToString();
                //book.Author = author;

                book.Title = sqliteDataReader[3].ToString();                
                book.Genre = (LiteraryGenres)Convert.ToInt32(sqliteDataReader[4]);
                book.YearPublication = Convert.ToUInt32(sqliteDataReader[5]);
                book.Content = sqliteDataReader[6].ToString();
                Books.Add(book);
            }
            sqliteDataReader.Close();
            connection.CloseConnection();
        }


        internal static void ShowBooks(List<Book> Books)
        {
            //запрос к БД на выборку из 2 таблиц(автор, книга) - возвращает ФИО_автора, название_книги, жанр_книги, год_издания
            string sqlQuery = "SELECT BookAuthor.SurnameAuthor, BookAuthor.NameAuthor, " +
                "BookAuthor.MidlenameAuthor, Books.BookTitle, Books.BookGenres, " +
                "Books.BookYearPublication, Books.Content " +
                "FROM Books " +
                "LEFT JOIN BookAuthor " +
                "ON Books.BookAuthorID = BookAuthor.IdAuthor;";

            ConnectionDB connection = new ConnectionDB();
            connection.OpenConnection();
            SqliteCommand cmdSelectAllBooks = new SqliteCommand(sqlQuery, connection.GetConnection());
            SqliteDataReader sqliteDataReader = cmdSelectAllBooks.ExecuteReader();

            while (sqliteDataReader.Read())
            {
                Book book = new();

                BookAuthor author = new();
                author.Surname = sqliteDataReader[0].ToString();
                author.Name = sqliteDataReader[1].ToString();
                author.MidleName = sqliteDataReader[2].ToString();
                book.Author = author;

                //string author;
                //author = sqliteDataReader[0].ToString();
                //author = author + " " + sqliteDataReader[1].ToString();
                //author = author + " " + sqliteDataReader[2].ToString();
                //book.Author = author;

                book.Title = sqliteDataReader[3].ToString();
                book.Genre = (LiteraryGenres)Convert.ToInt32(sqliteDataReader[4]);
                book.YearPublication = Convert.ToUInt32(sqliteDataReader[5]);
                book.Content = sqliteDataReader[6].ToString();
                Books.Add(book);                
            }
            sqliteDataReader.Close();
            connection.CloseConnection();
        }
    }
}
