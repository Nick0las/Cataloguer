using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Xaml.Behaviors;

namespace Cataloguer.Resources.Behaviors
{
    internal class CloseWindow : Behavior <Button>
    {
        protected override void OnAttached() => AssociatedObject.Click += OnButtonClick;

        protected override void OnDetaching() => AssociatedObject.Click -= OnButtonClick;
        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            var button = AssociatedObject;
            var window = FindVisualRoon(button) as Window;
            window?.Close();
        }

        private static DependencyObject FindVisualRoon(DependencyObject obj)
        {
            do
            {
                var parent = VisualTreeHelper.GetParent(obj);
                if (parent is null) return obj;
                obj = parent;
            }
            while(true);
        }
    }
}
