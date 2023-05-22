using Cataloguer.Commands;
using Cataloguer.Models;
using Cataloguer.Services;
using Cataloguer.ViewModels.ValidatableViewModelBase;
using Cataloguer.Resources.Interfaces;
using Cataloguer.ViewModels.ViewModel_Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Cataloguer.ViewModels
{
    internal class AddNewBook_VM : ValidatableVMBase
    {
        #region заголовок окна
        private string title = "+1 к коллекции книг!";
        /// <summary>Заголовок окна </summary>
        public string Title
        {
            get => title;
            set => Set(ref title, value);
        }
        #endregion

        #region Свойства для передачи строковых данных из представления       
        
        /// <summary>Название произведения</summary>
        private string titleBook;
        public string TitleBook
        {
            get => titleBook;
            set => Set(ref titleBook, value);
        }

        /// <summary>Жанры произведений</summary>
        private int selectedGenres;
        public int SelectedGenres
        {
            get => selectedGenres;
            set => Set(ref selectedGenres, value);
        }

        /// <summary>Год издания</summary>
        private string yearPublicationBook;
        public string YearPublicationBook
        {
            get => yearPublicationBook;
            set => Set(ref yearPublicationBook, value);
        }
        /// <summary>Краткое описание произведения</summary>
        private string contentBook;
        public string ContentBook
        {
            get => contentBook;
            set => Set(ref contentBook, value);
        }


        #endregion

        #region Свойства для ComboBox выбор автора
        /// <summary>выбранный автор из ComboBox</summary>
        private BookAuthor selectedAutor;
        public BookAuthor SelectedAuthor
        {
            get => selectedAutor;
            set => Set(ref selectedAutor, value);
        }

        #endregion

        #region Команда добавления новой книги
        /// <summary>Команда добавления новой книги</summary>
        public ICommand AddNewBookCmd { get; }
        private bool CanAddNewBookCmdExecute(object p) => true;
        private void OnAddNewBookCmdExecuted(object p)
        {   
            Book book = new();
            BookAuthor bookAuthor = new();
            bookAuthor = SelectedAuthor;
            book.Author = bookAuthor;
            book.Title = TitleBook;
            book.Genre = (LiteraryGenres)SelectedGenres;

            //проверка на корректный ввод данных года издания через регулярные выражения
            bool flagYear = ValidateEnterYearPublicationBook(book, YearPublicationBook);
            if(flagYear == false) return;

            book.Content = ContentBook;
            //Collections.BooksObsCollection.Add(book);
        }
        #endregion

        public AddNewBook_VM()
        {
            Collections.BookAuthorCollection.Clear();
            IDownloadAuthors.ShowAuthors(Collections.BookAuthorCollection);
            AddNewBookCmd = new LamdaCommand(OnAddNewBookCmdExecuted, CanAddNewBookCmdExecute);
        }


        /// <summary>переопределенный метод проверки на валидность введенной пользователем информации.</summary>
        protected override string Validate(string columnName)
        {
            if (columnName == nameof(YearPublicationBook))
            {
                if (String.IsNullOrWhiteSpace(YearPublicationBook))
                {
                    return "Поле 'Год издания' не может быть пустым";
                }
                if (!Int32.TryParse(YearPublicationBook, out var value))
                {
                    return "В данное поле допускается ввод только цифр! (целое число)";
                }
            }

            return String.Empty;
        }

        

        ///<summary>Метод на корректный ввод данных о годе издания книги</summary>
        private  bool ValidateEnterYearPublicationBook(Book _book,string yearPublicationBook)
        {
            if (!Regex.IsMatch(yearPublicationBook, @"^[0-9]+$") || yearPublicationBook is null)
            {
                MessageBox.Show("Игнорируя предупреждения вы все таки допустили ошибку!", "Внимание! Исправьте ввод года издания!",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (Convert.ToInt32(yearPublicationBook) <= 0)
            {
                MessageBox.Show("Игнорируя предупреждения вы все таки допустили ошибку!", "Внимание! Число может быть только положительным и больше 0!",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            
            _book.YearPublication = Convert.ToUInt32(yearPublicationBook);
            return true;
            
        }

    }
}
