using Cataloguer.Models;
using Cataloguer.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cataloguer.Services
{
    class BookRepositry : RepositoryInMemory<Book>
    {
        protected override void Update(Book Source, Book Destination)
        {
            Destination.Id = Source.Id;
            Destination.Author = Source.Author;
            Destination.Title = Source.Title;
            Destination .Genre = Source.Genre;
            Destination.YearPublication = Source.YearPublication;
            Destination.Content = Source.Content;
        }
    }

    class AuthorRepositry : RepositoryInMemory<BookAuthor>
    {
        protected override void Update(BookAuthor Source, BookAuthor Destination)
        {
            Destination.Id = Source.Id;
            Destination.Surname = Source.Surname;
            Destination.Name = Source.Name;
            Destination.MidleName = Source.MidleName;
        }
    }

}
