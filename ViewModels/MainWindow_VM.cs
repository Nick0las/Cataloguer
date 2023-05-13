using Cataloguer.Models;
using Cataloguer.ViewModels.ViewModel_Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cataloguer.ViewModels
{
    internal class MainWindow_VM : BaseViewModel
    {
        #region заголовок окна
        private string title = "Каталогизатор";
        /// <summary>Заголовок окна </summary>
        public string Title
        {
            get => title;
            set => Set(ref title, value);
        }
        #endregion

        //конструктор
        public MainWindow_VM()
        {
            
        }
    }
}
