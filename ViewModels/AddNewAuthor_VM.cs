﻿using Cataloguer.Commands;
using Cataloguer.Models;
using Cataloguer.ViewModels.ViewModel_Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cataloguer.ViewModels
{
    internal class AddNewAuthor_VM : BaseViewModel
    {
        #region заголовок окна
        private string title = "+1 автор в каталоге!";
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
        #endregion

        #region Команда добавления нового автора
        /// <summary>Команда добавления нового автора</summary>
        public ICommand AddNewAuthorCmd { get; }
        private bool CanAddNewAuthorCmdExecute(object p) => true;
        private void OnAddNewAuthorCmdExecuted(object p)
        {
            BookAuthor bookAuthor = new();
            //проверка на корректный ввод данных ФИО автора через регулярные выражения
            bool flag = ValidateEnterBookAuthor(bookAuthor, SurnameAuthor, NameAuthor, MidllenameAuthor);
            if (flag == false) return;
        }

       


        #endregion

        

            public AddNewAuthor_VM()
        {
            AddNewAuthorCmd = new LamdaCommand(OnAddNewAuthorCmdExecuted, CanAddNewAuthorCmdExecute);
        }



        /// <summary>Метод с использованием регулярных выражений на проверку корректности ввода ФИО автора</summary>        
        private bool ValidateEnterBookAuthor(BookAuthor author, string surname, string name, string middleName)
        {
            /*проверка фамилии*/
            if (!Regex.IsMatch(surname, @"^[a-zA-Zа-яА-Я]+$") || surname is null)
            {
                MessageBox.Show("Игнорируя предупреждения вы все таки допустили ошибку!", "Внимание! Исправьте Фамилию Автора!",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            else
            {
                author.Surname = surname;
            }
            /*проверка имени*/
            if (!Regex.IsMatch(name, @"^[a-zA-Zа-яА-Я]+$") || name is null)
            {
                MessageBox.Show("Игнорируя предупреждения вы все таки допустили ошибку!", "Внимание! Исправьте Имя Автора!",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            else
            {
                author.Name = name;
            }

            /*проверка отчества*/
            if (middleName != null)
            {
                if (!Regex.IsMatch(middleName, @"^[a-zA-Zа-яА-Я]+$"))
                {
                    MessageBox.Show("Игнорируя предупреждения вы все таки допустили ошибку!", "Внимание! Исправьте Отчество Автора!",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
                else
                {
                    author.MidleName = middleName;
                }
            }
            return true;

        }
    }
}
