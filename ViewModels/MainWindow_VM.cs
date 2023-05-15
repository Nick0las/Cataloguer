using Cataloguer.Models;
using Cataloguer.Resources.Interfaces;
using Cataloguer.Services;
using Cataloguer.ViewModels.ViewModel_Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
//using Microsoft.Data.Sqlite;


namespace Cataloguer.ViewModels
{
    internal class MainWindow_VM : BaseViewModel
    {
        #region Свойства, привязанные к окну
        #region заголовок окна
        private string title = "Тестовое задание";
        /// <summary>Заголовок окна </summary>
        public string Title
        {
            get => title;
            set => Set(ref title, value);
        }
        #endregion

        /*Свойство для выбора книги*/
        private Book selectedBook;
        public Book SelectedBook { get => selectedBook;set => Set(ref selectedBook, value); }
        /*--------------------------------------------------------------------------------------------------------------*/
        #endregion

        public ObservableCollection<Book> BooksObsCollection { get; }        

        //конструктор
        public MainWindow_VM()
        {
            IDownloadAllBooks.ShowBooks(Collections.BooksICollections);            
            BooksObsCollection = new ObservableCollection<Book>(Collections.BooksICollections);
        }
    }
}
