using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cataloguer.Models
{
    internal class BookAuthor
    {
        /// <summary>ID автора книги</summary>
        public int? IdAuhtor { get; set; }
        /// <summary>Фамилия автора книги</summary>
        public string Surname { get; set; }

        /// <summary>Имя автора книги</summary>
        public string Name { get; set; }

        /// <summary>Отчество автора книги</summary>
        public string? MidleName { get; set; }
        /// <summary>Прокси свойство для передачи в ComboBox</summary>
        public string FullName => $"{Surname} {Name} {MidleName}";
        

    }
}
