

using System.Collections.Generic;

namespace Cataloguer.Models
{
    internal class Book
    {
        public BookAuthor? Author { get; set; }
        
        ///<summary>автор книги</summary>
        //public string? Author { get; set; }

        ///<summary> название книги </summary>
        public string Title { get; set; }

        ///<summary> тематика книг </summary>
        public LiteraryGenres Genre { get; set; }

        ///<summary> год издания</summary>
        public uint YearPublication { get; set; }
        public string? Content { get; set; }

        public ICollection<Book> BooksCollections { get; set; }
    }
}
