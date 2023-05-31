using Cataloguer.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace Cataloguer.Models
{
    /// <summary>Класс автора книг</summary>
    internal class BookAuthor : IEntity
    {
        /// <summary>ID автора книги</summary>
        public int? Id { get; set; }

        /// <summary>Фамилия автора книги</summary>
        public string Surname { get; set; }

        /// <summary>Имя автора книги</summary>
        public string Name { get; set; }

        /// <summary>Отчество автора книги</summary>
        public string? MidleName { get; set; }

        /// <summary>Прокси свойство для передачи в ComboBox</summary>
        public string FullName => $"{Surname} {Name} {MidleName}";
    }


    internal class Book : IEntity 
    {
        public int? Id { get; set; }

        public BookAuthor? Author { get; set; }

        ///<summary> название книги </summary>
        public string Title { get; set; }

        ///<summary> тематика книг </summary>
        public LiteraryGenres Genre { get; set; }

        ///<summary> год издания</summary>
        public uint? YearPublication { get; set; }
        public string? Content { get; set; }
    
    }
}
