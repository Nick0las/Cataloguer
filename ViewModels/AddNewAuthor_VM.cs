using Cataloguer.ViewModels.ViewModel_Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }
}
