

namespace Cataloguer.Models
{
    internal class Book
    {
        ///<summary> автор книги </summary>
        public BookAuthor? Author { get; set; }

        ///<summary> название книги </summary>
        public string Title { get; set; }

        ///<summary> тематика книг </summary>
        public LiteraryGenres Genre { get; set; }

        ///<summary> год издания</summary>
        public uint YearPublication { get; set; }
    }
}
