using Cataloguer.Models;
using Cataloguer.Resources.Interfaces;
using Cataloguer.Services;
using Cataloguer.ViewModels.ViewModel_Base;
//using Microsoft.Data.Sqlite;


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
            IDownloadAllBooks.ShowBooks(Collections.BooksListCollection);
            IDownloadAllBooks.ShowBooks(Collections.BooksObsCollection);
        }
    }
}
