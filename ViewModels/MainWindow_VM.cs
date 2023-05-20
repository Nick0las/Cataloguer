using Cataloguer.Commands;
using Cataloguer.Models;
using Cataloguer.Resources.Interfaces;
using Cataloguer.Services;
using Cataloguer.ViewModels.ViewModel_Base;
using Cataloguer.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Cataloguer.ViewModels
{
    internal class MainWindow_VM : BaseViewModel
    {
        
        #region заголовок окна
        private string title = "Тестовое задание";
        /// <summary>Заголовок окна </summary>
        public string Title
        {
            get => title;
            set => Set(ref title, value);
        }
        #endregion

        #region Свойство ObservableCollection, для отображения коллекции в DataGrid
        //public ObservableCollection<Book> BooksObsCollection { get; }
        #endregion

        #region Свойства для выделенной строки в DataGrid
        /*Свойство для выбора книги*/
        private Book selectedBook;
        public Book SelectedBook 
        {
            get => selectedBook;
            set => Set(ref selectedBook, value); 
            
        }
        /*--------------------------------------------------------------------------------------------------------------*/
        private int? selectedBookIndex = null;
        public int? SelectedBookIndex
        {
            get => selectedBookIndex;
            set => Set(ref selectedBookIndex, value);

        }

        #endregion

       


        //конструктор
        public MainWindow_VM()
        {   
            IDownloadAllBooks.ShowBooks(Collections.BooksObsCollection);
        }

        
    }
}
