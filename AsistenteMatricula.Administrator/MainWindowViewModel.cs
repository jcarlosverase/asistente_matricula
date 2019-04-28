using AsistenteMatricula.Administrator.Library;
using AsistenteMatricula.Administrator.View.Universidad;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsistenteMatricula.Administrator
{
    public class MainWindowViewModel : NavigationPage
    {
        public MainWindowViewModel()
        {
            IsOpenMenu = false;
            CollectionMenuItem.Add(new MenuItem()
            {
                Title = "Universidad",
                Page = new VPG_Universidad()
            });
        }

        private bool _IsOpenMenu;
        public bool IsOpenMenu
        {
            get
            {
                return _IsOpenMenu;
            }
            set
            {
                _IsOpenMenu = value;
                OnPropertyChanged("IsOpenMenu");
            }
        }

        private MenuItem _SelectedMenuItem;
        public MenuItem SelectedMenuItem
        {
            get
            {
                return _SelectedMenuItem;
            }

            set
            {
                _SelectedMenuItem = value;
                if (value != null)
                {
                    Ir(value.Page, string.Empty);
                    IsOpenMenu = false;
                }
                OnPropertyChanged("SelectedMenuItem");
            }
        }

        private ObservableCollection<MenuItem> _CollectionMenuItem;
        public ObservableCollection<MenuItem> CollectionMenuItem
        {
            get
            {
                if (_CollectionMenuItem == null)
                    _CollectionMenuItem = new ObservableCollection<MenuItem>();
                return _CollectionMenuItem;
            }
            set
            {
                _CollectionMenuItem = value;
                OnPropertyChanged("CollectionMenuItem");
            }
        }

    }
}
