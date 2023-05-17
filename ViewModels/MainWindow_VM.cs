using Cataloguer.Models;
using Cataloguer.Resources.Interfaces;
using Cataloguer.Services;
using Cataloguer.ViewModels.ViewModel_Base;
using OxyPlot;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;



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

        #region Свойство для выделенной строки в DataGrid
        /*Свойство для выбора книги*/
        private Book selectedBook;
        public Book SelectedBook 
        {
            get => selectedBook;
            set => Set(ref selectedBook, value); 
            
        }
        /*--------------------------------------------------------------------------------------------------------------*/
        #endregion




        //конструктор
        public MainWindow_VM()
        {
            IDownloadAllBooks.ShowBooks(Collections.BooksObsCollection);
        }
    }
}
