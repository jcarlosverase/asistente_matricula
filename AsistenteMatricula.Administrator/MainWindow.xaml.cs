using MahApps.Metro.Controls;
using MaterialDesignThemes.Wpf;
using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace AsistenteMatricula.Administrator
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //until we had a StaysOpen glag to Drawer, this will help with scroll bars
            var dependencyObject = Mouse.Captured as DependencyObject;
            while (dependencyObject != null)
            {
                if (dependencyObject is ScrollBar) return;
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }

            MenuToggleButton.IsChecked = false;
        }

        private   void MenuPopupButton_OnClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://sharedcss.com/haacc/AsistenteMatricula.Portal/Account/Login");
        }

        private void OnCopy(object sender, ExecutedRoutedEventArgs e)
        {
            //if (e.Parameter is string stringValue)
            //{
            //    try
            //    {
            //        Clipboard.SetDataObject(stringValue);
            //    }
            //    catch (Exception ex)
            //    {
            //        Trace.WriteLine(ex.ToString());
            //    }
            //}
        }
    }
}
