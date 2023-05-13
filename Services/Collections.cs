using Cataloguer.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Cataloguer.Services
{
    internal class Collections
    {
        /// <summary> Список List для возможности сортировки коллекции</summary>
        public static List<Book> BooksListCollection { get; set; } = new();

        /// <summary> для хранения и моментального отображения коллекции</summary>
        public static ObservableCollection<Book> BooksObsCollection { get; } = new();
    }
}
