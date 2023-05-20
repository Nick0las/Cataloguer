using Cataloguer.Models;
using Cataloguer.ViewModels.ValidatableViewModelBase;
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
    internal class EditBook_VM : ValidatableVMBase
    {

        #region заголовок окна
        private string title = "Редактирование данных о издании";
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

        #region Команды
        public ICommand EditBookCmd { get; }
        private bool CanEditBookCmdExecute(object p) => true;
        private void OnEditBookCmdExecuted(object p)
        {
            
        }

        #endregion




        public EditBook_VM()
        {
            EditBookCmd = new LamdaCommand(OnEditBookCmdExecuted, CanEditBookCmdExecute);
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
        private bool ValidateEnterYearPublicationBook(Book _book, string yearPublicationBook)
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
