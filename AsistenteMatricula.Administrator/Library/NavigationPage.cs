
namespace AsistenteMatricula.Administrator.Library
{
    using Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;

    public class NavigationPage : NotifyPropertyChanged
    {
        private IDictionary<Type, string> ViewModelRouting;

        public void Volver(string NameFrame = "")
        {

            Application.Current.Dispatcher.Invoke(() =>
            {
                Frame MyFrame = null;
                if (MyFrame == null)
                    MyFrame = GetCurrentWindowFrame().Where(x => x.Name == ((NameFrame.Length != 0) ? NameFrame : "MyNavegacion")).FirstOrDefault();
                if (MyFrame == null)
                    MyFrame = GetCurrentWindowFrame().Where(x => x.Name == ((NameFrame.Length != 0) ? NameFrame : "MyFrameBody")).FirstOrDefault();

                if (MyFrame == null)
                    MyFrame = GetCurrentWindowFrame().Where(x => x.Name == ((NameFrame.Length != 0) ? NameFrame : "MyFrame")).FirstOrDefault();

                if (MyFrame == null)
                {
                    throw new Exception("No se puede encontrar el elemento Frame con el nombre MyNavegacion ó MyFrameBody");
                }
                if (MyFrame.NavigationService.CanGoBack)
                    MyFrame.NavigationService.GoBack();
                else
                {

                    //Verificamos si cerramos o navegamos
                    var SingleWindowIsActive = GetCurrentWindow();
                    if (SingleWindowIsActive == null) return;
                    if (SingleWindowIsActive.GetType().Name == "ViewNavigate")
                        SingleWindowIsActive.Close();
                }
                //MyFrame.NavigationPage.Refresh();
            });

        }

        public void Ir(object valueobject, Frame MyFrame = null, string NameFrame = "")
        {
            Application.Current.Dispatcher.Invoke(() =>
            {  
                if (MyFrame == null)
                    MyFrame = GetCurrentWindowFrame().Where(x => x.Name == ((NameFrame.Length != 0) ? NameFrame : "MyNavegacion")).FirstOrDefault();
                if (MyFrame == null)
                    MyFrame = GetCurrentWindowFrame().Where(x => x.Name == ((NameFrame.Length != 0) ? NameFrame : "MyFrameBody")).FirstOrDefault();

                if (MyFrame == null)
                    MyFrame = GetCurrentWindowFrame().Where(x => x.Name == ((NameFrame.Length != 0) ? NameFrame : "MyFrame")).FirstOrDefault();
                MyFrame.NavigationService.Navigate(valueobject);
            });
        }

        public void Ir(object valueobject, object parameters, Frame MyFrame = null, string NameFrame = "")
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    if (MyFrame == null)
                        MyFrame = GetCurrentWindowFrame().Where(x => x.Name == ((NameFrame.Length != 0) ? NameFrame : "MyNavegacion")).FirstOrDefault();
                    if (MyFrame == null)
                        MyFrame = GetCurrentWindowFrame().Where(x => x.Name == ((NameFrame.Length != 0) ? NameFrame : "MyFrameBody")).FirstOrDefault();

                    if (MyFrame == null)
                        MyFrame = GetCurrentWindowFrame().Where(x => x.Name == ((NameFrame.Length != 0) ? NameFrame : "MyFrame")).FirstOrDefault();
                     
                    MyFrame.Navigated += new NavigatedEventHandler(this._NavigatedEventHandler);

                    this.Parameters = parameters;
                    this.frame = MyFrame;
                    MyFrame.NavigationService.Navigate(valueobject);
                }
                catch (Exception)
                { }
            });
        }

        private Window GetCurrentWindow()
        {
            var ListWindows = Application.Current.Windows.Cast<Window>();
            var item = Application.Current.Windows.Cast<Window>().
                                        SingleOrDefault(x => x.IsActive);
            if (item == null)
                item = ListWindows.FirstOrDefault();

            return item;
        }

        private List<Frame> GetCurrentWindowFrame()
        {
            return GetChildren.FindVisualChildren<Frame>(GetCurrentWindow()).ToList();
        }

        private void _NavigatedEventHandler(object sender, NavigationEventArgs e)
        {
            this.frame.Navigated -= new NavigatedEventHandler(this._NavigatedEventHandler);
            if (e.Content is Page)
            {
                if (((e.Content as Page).DataContext is INavigationPage))
                {
                    var instDataContext = ((e.Content as Page).DataContext);  
                    (instDataContext as INavigationPage).Parameter = this.Parameters; 
                }
            }
            else if (e.Content is UserControl)
            {
                if ((((UserControl)e.Content).DataContext is INavigationPage))
                {
                    (((UserControl)e.Content).DataContext as INavigationPage).Parameter = this.Parameters;
                    //(((UserControl)e.Content).DataContext as INavigationPage).MyFrame = this.frame;
                }
            }
        }

        private object _Parameters;
        public object Parameters
        {
            get
            {
                return this._Parameters;
            }
            set
            {
                this._Parameters = value;
                this.OnPropertyChanged("Parameters");
            }
        }

        public Frame frame { get; set; }
        
    }
     
}
