using Cataloguer.ViewModels.ViewModel_Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cataloguer.ViewModels
{
    internal class AddNewBook : BaseViewModel
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
    }
}
