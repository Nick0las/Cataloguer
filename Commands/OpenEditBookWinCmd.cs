using Cataloguer.Commands.Base_command;
using Cataloguer.Views;
using System;
using System.Windows;

namespace Cataloguer.Commands
{
    internal class OpenEditBookWinCmd : BaseCommand
    {
        private EditBookWindow _Window;
        public override bool CanExecute(object parameter) => _Window == null;
        public override void Execute(object parameter)
        {
            EditBookWindow window = new EditBookWindow
            {
                Owner = Application.Current.MainWindow
            };
            _Window = window;
            window.Closed += OnWindowClosed;
            window.ShowDialog();
        }

        private void OnWindowClosed(object Sender, EventArgs E)
        {
            ((Window)Sender).Closed -= OnWindowClosed;
            _Window = null;
        }
    }
}
