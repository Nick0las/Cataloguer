using Cataloguer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cataloguer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            
        }

        private void BooksCollectionsFilter(object sender, FilterEventArgs e)
        {
            if (!(e.Item is Book book)) return;

            var filter_text = TextBoxGenreFilter.Text;
            if(filter_text.Length == 0) return;

            if(book.YearPublication.ToString().Contains(filter_text, StringComparison.OrdinalIgnoreCase)) return;
            if (book.YearPublication.ToString().Contains(filter_text, StringComparison.OrdinalIgnoreCase)) return;            
            e.Accepted = false;
        }

        private void OnTitleFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            var text_box = (TextBox)sender;
            var collections = (CollectionViewSource)text_box.FindResource("CollectionsBooksByGenre");
            collections.View.Refresh();
        }
    }
}
