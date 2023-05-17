using Cataloguer.Commands;
using Cataloguer.Models;
using Cataloguer.Services;
using Cataloguer.ViewModels.ValidatableViewModelBase;
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
       
        /// <summary>Фамилия автора</summary>
        private string? surnameAuthor;
        public string? SurnameAuthor
        {
            get => surnameAuthor;
            set => Set(ref surnameAuthor, value);
        }

        /// <summary>Имя автора</summary>
        private string nameAuthor;
        public string NameAuthor
        {
            get => nameAuthor;
            set => Set(ref nameAuthor, value);
        }

        /// <summary>Отчество автора</summary>
        private string? midllenameAuthor;
        public string? MidllenameAuthor
        {
            get => midllenameAuthor;
            set => Set(ref midllenameAuthor, value);
        }

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

        #region Команда добавления новой книги
        /// <summary>Команда добавления новой книги</summary>
        public ICommand AddNewBookCmd { get; }
        private bool CanAddNewBookCmdExecute(object p) => true;
        private void OnAddNewBookCmdExecuted(object p)
        {   
            Book book = new();
            BookAuthor bookAuthor = new();
            bookAuthor.Surname = SurnameAuthor;
            bookAuthor.Name = NameAuthor;
            bookAuthor.MidleName = MidllenameAuthor;
            book.Author = bookAuthor;
            book.Title = TitleBook;
            book.Genre = (LiteraryGenres)SelectedGenres;
            if(Regex.IsMatch(YearPublicationBook, @"^[a-zA-Z0-9_!@#$%^&*()-+=\|/<>]+$") || Regex.IsMatch(YearPublicationBook, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Игнорируя предупреждения вы все таки допустили ошибку!", "Внимание! Исправьте ввод года издания!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                book.YearPublication = Convert.ToUInt32(YearPublicationBook);
            }
            
            book.Content = ContentBook;

            Collections.BooksObsCollection.Add(book);
        }
        #endregion

        public AddNewBook_VM()
        {
            AddNewBookCmd = new LamdaCommand(OnAddNewBookCmdExecuted, CanAddNewBookCmdExecute);
        }

        /// <summary>
        /// переопределенный метод проверки на валидность введенной пользователем информации.
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
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

        

    }
}
