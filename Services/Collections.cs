using Cataloguer.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Cataloguer.Services
{
    internal class Collections
    {
        /// <summary> для хранения коллекции</summary>
        public static ObservableCollection<Book> BooksObsCollection { get; set; } = new();
        
        public static ObservableCollection<BookAuthor> BookAuthorCollection { get; set; } = new();
    }
}
