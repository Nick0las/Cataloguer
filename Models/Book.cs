using Cataloguer.Models.Interfaces;
using System;



namespace Cataloguer.Models
{
    internal class Book : IEntity 
    {
        public int? Id { get; set; }

        public BookAuthor? Author { get; set; }

        ///<summary> название книги </summary>
        public string Title { get; set; }

        ///<summary> тематика книг </summary>
        public LiteraryGenres Genre { get; set; }

        ///<summary> год издания</summary>
        public uint YearPublication { get; set; }
        public string? Content { get; set; }
    }
}
