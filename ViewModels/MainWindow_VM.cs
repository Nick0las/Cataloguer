using Cataloguer.Models;
using Cataloguer.Resources.Interfaces;
using Cataloguer.ViewModels.ViewModel_Base;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

        #region Свойство ObservableCollection, для отображения книг в DataGrid
        private ObservableCollection<Book> booksCollectionProperty;
        public ObservableCollection<Book> BooksCollectionProperty
        {
            get => booksCollectionProperty;
            set
            {
                if (!Set(ref booksCollectionProperty, value)) return;
                _CollectionViewBook.Source = value;
            }
        }
        
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


    #region Фильтрация

      #region CollectionViewSource
        private readonly CollectionViewSource _CollectionViewBook = new ();
        public ICollectionView CollectionViewBook => _CollectionViewBook?.View;
      #endregion

        #region Свойство к TextBoxYear

        private string textBoxFilterYear;
        public string TextBoxFilterYear
        {
            get => textBoxFilterYear;
            set
            {
                if(!Set(ref textBoxFilterYear, value)) return;
                _CollectionViewBook.View.Refresh();
            }
        }
        #endregion

        #region Свойство к TextBoxGenre

        private string textBoxFilterAuthor;
        public string TextBoxFilterAuthor
        {
            get => textBoxFilterAuthor;
            set
            {
                if(!Set(ref textBoxFilterAuthor, value)) return;
                _CollectionViewBook?.View.Refresh();
            }
        }

        #endregion


        #region метод фильтрации
        /// <summary>
        ///метод фильтрации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBookFilterByYear(object sender, FilterEventArgs e)
        {
            var filter_text = textBoxFilterYear;

            if (!(e.Item is Book book)) return;
            if (String.IsNullOrWhiteSpace(filter_text)) return;

            if (book.YearPublication.ToString().Contains(filter_text, StringComparison.OrdinalIgnoreCase)) return;
            e.Accepted = false;

        }
        private void OnBookFilterByAuthor(object sender, FilterEventArgs e)
        {
            var filter_text = textBoxFilterAuthor;
            if (!(e.Item is Book book)) return;
            if(String.IsNullOrWhiteSpace(filter_text)) return;
            if(book.Author.Name.ToString().Contains(filter_text, StringComparison.OrdinalIgnoreCase)) return;
            if (book.Author.Surname.ToString().Contains(filter_text, StringComparison.OrdinalIgnoreCase)) return;
            if (book.Author.MidleName.ToString().Contains(filter_text, StringComparison.OrdinalIgnoreCase)) return;
            e.Accepted=false;
        }

        #endregion

        #endregion





        //конструктор
        public MainWindow_VM()
        {
            BooksCollectionProperty = new ObservableCollection<Book>();
            IDownloadAllBooks.ShowBooks(BooksCollectionProperty);
            _CollectionViewBook.Filter += OnBookFilterByYear;
            _CollectionViewBook.Filter += OnBookFilterByAuthor;
        }

        
    }
}
